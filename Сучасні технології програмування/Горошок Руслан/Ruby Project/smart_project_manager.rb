#!/usr/bin/env ruby
require "json"

module Identifiable
  def generate_id
    @id = (Time.now.to_f * 1000).to_i
  end
  attr_reader :id
end

module Printable
  def pp
    puts JSON.pretty_generate(to_h)
  end
end

module Logger
  def log(message)
    puts "LOG: #{message}"
  end
end

class Status
  ALL = %i[pending in_progress done archived]
end

class Priority
  ALL = %i[low medium high critical]
end

class Task
  include Identifiable, Printable

  attr_accessor :title, :description, :status, :priority, :estimated_hours

  def initialize(title, description, priority=:medium, hours=1, status=:pending)
    @title = title
    @description = description
    @priority = priority
    @estimated_hours = hours
    @status = status
    generate_id
  end

  def to_h
    { id: id, title: title, description: description, status: status, priority: priority, estimated_hours: estimated_hours }
  end
end

class TaskRepository
  include Logger

  def initialize
    @tasks = []
  end

  def add(task)
    log("Task '#{task.title}' added")
    @tasks << task
  end

  def all
    @tasks
  end

  def find_by_index(index)
    @tasks[index]
  end

  def update_by_index(index, **attrs)
    task = find_by_index(index)
    return unless task
    attrs.each { |k,v| task.send("#{k}=", v) }
    log("Task '#{task.title}' updated")
  end

  def delete_by_index(index)
    task = @tasks[index]
    return unless task
    log("Task '#{task.title}' deleted")
    @tasks.delete_at(index)
  end
end

class Analytics
  def initialize(repo)
    @repo = repo
  end

  def stats
    tasks = @repo.all
    return puts "No tasks available for analytics." if tasks.empty?

    puts "\nPROJECT ANALYTICS\n--------------------------"
    total_tasks = tasks.size
    puts "Total tasks: #{total_tasks}"

    puts "\nBy status:"
    Status::ALL.each do |st|
      filtered = tasks.select { |t| t.status == st }
      puts "  #{st}: #{filtered.size}"
      puts "     Avg estimated hours: #{(filtered.map(&:estimated_hours).sum / filtered.size.to_f).round(2)}" unless filtered.empty?
    end

    puts "\nBy priority:"
    Priority::ALL.each do |p|
      filtered = tasks.select { |t| t.priority == p }
      puts "  #{p}: #{filtered.size} tasks, total estimated hours: #{filtered.map(&:estimated_hours).sum}"
    end

    avg_desc = tasks.map { |t| t.description.length }.sum / total_tasks.to_f
    total_hours = tasks.map(&:estimated_hours).sum
    done_count = tasks.count { |t| t.status == :done }
    high_priority_percent = tasks.count { |t| [:high, :critical].include?(t.priority) } * 100.0 / total_tasks
    remaining_hours = tasks.select { |t| [:pending, :in_progress].include?(t.status) }.map(&:estimated_hours).sum
    avg_done_hours = done_count > 0 ? tasks.select { |t| t.status == :done }.map(&:estimated_hours).sum / done_count.to_f : 1
    estimated_days = (remaining_hours / avg_done_hours).round(1)

    puts "\nAverage description length: #{avg_desc.round(2)} characters"
    puts "Total estimated work: #{total_hours} hours"
    puts "Project progress: #{(done_count * 100.0 / total_tasks).round(1)}%"
    puts "High-priority tasks: #{high_priority_percent.round(1)}%"
    puts "Estimated time to complete remaining tasks (in avg 'done' units): #{estimated_days} units"
  end
end

class UI
  MOTIVATION = ["You're doing great!", "Each step is progress.", "Keep it up.", "Stay focused and keep working."]

  def initialize(repo)
    @repo = repo
    @analytics = Analytics.new(repo)
  end

  def start
    loop do
      show_menu
      choice = safe_get_int
      case choice
      when 1 then add_task
      when 2 then list_tasks
      when 3 then update_status
      when 4 then update_priority
      when 5 then delete_task
      when 6 then @analytics.stats
      when 7 then puts "\n#{MOTIVATION.sample}"
      when 8 then exit_program
      else puts "Unknown option."
      end
    end
  end

  def show_menu
    puts "\n========= SMART PROJECT MANAGER ========="
    puts "1. Add task\n2. Show all tasks\n3. Update status\n4. Update priority\n5. Delete task\n6. Show analytics\n7. Motivation\n8. Exit"
    puts "========================================="
  end

  def safe_get_int(allow_nil=false)
    input = gets&.strip
    return nil if input.nil? && allow_nil
    Integer(input) rescue (allow_nil && (input.nil? || input.empty?) ? nil : -1)
  end

  def choose_task_index
    tasks = @repo.all
    return nil if tasks.empty?

    loop do
      puts "\nAvailable tasks:"
      tasks.each_with_index { |t, i| puts "#{i+1}. #{t.title} (ID: #{t.id}) — status: #{t.status}, priority: #{t.priority}, estimated: #{t.estimated_hours}h" }
      puts "0. Cancel"
      print "Choose number (1-#{tasks.size}) or 0 to cancel: "
      raw = gets&.strip
      return nil if raw.nil? || raw.empty? || raw == "0"

      index = Integer(raw) rescue nil
      return index - 1 if index && index.between?(1, tasks.size)
      puts "Invalid choice. Try again."
    end
  end

  def add_task
    print "Title: "; title = gets&.strip.to_s
    print "Description: "; desc = gets&.strip.to_s
    print "Priority (#{Priority::ALL.join(', ')}). Empty = medium: "; pr_raw = gets&.strip
    priority = pr_raw.nil? || pr_raw.empty? ? :medium : pr_raw.to_sym
    priority = :medium unless Priority::ALL.include?(priority)
    print "Estimated hours (number, empty = 1): "; hours = (Integer(gets&.strip) rescue 1)
    hours = 1 if hours <= 0
    @repo.add(Task.new(title, desc, priority, hours))
    puts "Task added."
  end

  def list_tasks
    tasks = @repo.all
    return puts "No tasks yet." if tasks.empty?
    puts "\nALL TASKS:"
    tasks.each_with_index do |t, i|
      puts "#{i+1}. #{t.title} (ID: #{t.id})"
      puts "    Status: #{t.status} | Priority: #{t.priority} | Estimated: #{t.estimated_hours}h"
      puts "    Description: #{t.description}"
    end
  end

  def update_status
    index = choose_task_index
    return unless index
    print "New status (#{Status::ALL.join(', ')}): "; st = gets&.strip.to_s.to_sym
    if Status::ALL.include?(st)
      @repo.update_by_index(index, status: st)
      puts "Status updated."
    else
      puts "Invalid status."
    end
  end

  def update_priority
    index = choose_task_index
    return unless index
    print "New priority (#{Priority::ALL.join(', ')}): "; p = gets&.strip.to_s.to_sym
    if Priority::ALL.include?(p)
      @repo.update_by_index(index, priority: p)
      puts "Priority updated."
    else
      puts "Invalid priority."
    end
  end

  def delete_task
    index = choose_task_index
    return unless index
    print "Confirm deletion (y/n): "; ans = gets&.strip.to_s.downcase
    if %w[y yes].include?(ans)
      @repo.delete_by_index(index)
      puts "Task deleted."
    else
      puts "Deletion cancelled."
    end
  end

  def exit_program
    puts "Goodbye!"
    exit
  end
end

if __FILE__ == $0
  UI.new(TaskRepository.new).start
end
