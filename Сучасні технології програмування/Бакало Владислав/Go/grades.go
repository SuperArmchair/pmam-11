package main

// Імпортування необхідних пакетів для вводу, виводу, графіків та конвертацій
import (
	"bufio"
	"fmt"
	"image/color"
	"os"
	"strconv"

	"gonum.org/v1/plot"
	"gonum.org/v1/plot/plotter"
	"gonum.org/v1/plot/vg"
)

// Структура для зберігання даних студента
type Student struct {
	Name        string
	Math        int
	Physics     int
	Programming int
	Average     float64
}

// Головна функція програми
func main() {
	reader := bufio.NewReader(os.Stdin)

	fmt.Print("Введіть кількість студентів: ")
	nStr, _ := reader.ReadString('\n')
	nStr = trim(nStr)
	n, err := strconv.Atoi(nStr)
	if err != nil || n <= 0 {
		fmt.Println("Невірна кількість студентів.")
		return
	}

	students := make([]Student, n)
	var sumMath, sumPhysics, sumProgramming float64

	// Ввід даних кожного студента та обчислення середнього
	for i := 0; i < n; i++ {
		fmt.Printf("\nВведіть дані про %d студента:\n", i+1)
		fmt.Print("Ім'я: ")
		name, _ := reader.ReadString('\n')
		name = trim(name)

		var math, phys, prog int
		fmt.Print("Оцінки з Математики, Фізики, Програмування (0-100): ")
		fmt.Scan(&math, &phys, &prog)
		reader.ReadString('\n') // очистка буфера

		avg := float64(math+phys+prog) / 3

		students[i] = Student{
			Name:        name,
			Math:        math,
			Physics:     phys,
			Programming: prog,
			Average:     avg,
		}

		sumMath += float64(math)
		sumPhysics += float64(phys)
		sumProgramming += float64(prog)
	}

	// Вивід детальних результатів студентів
	fmt.Println("\n Результати сесії: ")
	for i, s := range students {
		fmt.Printf("%d. %s — Математика = %d (%s), Фізика = %d (%s), Програмування = %d (%s), Середній = %.2f\n",
			i+1,
			s.Name,
			s.Math, getLevel(s.Math),
			s.Physics, getLevel(s.Physics),
			s.Programming, getLevel(s.Programming),
			s.Average)
	}

	// Вивід середніх балів групи
	fmt.Printf("\nСередній бал групи:\n")
	fmt.Printf("Математика = %.2f\n", sumMath/float64(n))
	fmt.Printf("Фізика = %.2f\n", sumPhysics/float64(n))
	fmt.Printf("Програмування = %.2f\n", sumProgramming/float64(n))

	// Підрахунок статистики по категоріях оцінок
	calcStatistics(students)

	// Відображення відмінників з Програмування
	fmt.Println("\nВідмінники з Програмування (оцінка ≥ 90):")
	for _, s := range students {
		if s.Programming >= 90 {
			fmt.Println(s.Name)
		}
	}

	// Визначення лідера групи за середнім балом
	leader := getLeader(students)
	if leader != nil {
		fmt.Printf("\nЛідер групи: %s (Середній = %.2f)\n", leader.Name, leader.Average)
	} else {
		fmt.Println("\nЛідер групи не визначений (всі мають хоча б одну оцінку 'Не склав')")
	}

	// Генерація графіків середніх балів та оцінок
	generateLinePlot(students)
	generateBarPlot(students)
	fmt.Println("\nГрафіки збережено: average_grades.png та grades_bar.png")
}

// Видалення символів \n та \r з введеного рядка
func trim(s string) string {
	for len(s) > 0 && (s[len(s)-1] == '\n' || s[len(s)-1] == '\r') {
		s = s[:len(s)-1]
	}
	return s
}

// Визначення категорії оцінки
func getLevel(mark int) string {
	switch {
	case mark <= 50:
		return "Не склав"
	case mark <= 70:
		return "Задовільно"
	case mark <= 89:
		return "Добре"
	case mark <= 100:
		return "Відмінно"
	default:
		return "Невірний бал"
	}
}

// Підрахунок та вивід статистики по кожній дисципліні
func calcStatistics(students []Student) {
	n := float64(len(students))
	mathCounts := map[string]int{}
	physCounts := map[string]int{}
	progCounts := map[string]int{}

	for _, s := range students {
		mathCounts[getLevel(s.Math)]++
		physCounts[getLevel(s.Physics)]++
		progCounts[getLevel(s.Programming)]++
	}

	fmt.Println("\nСтатистика по дисциплінах (% від студентів):")
	fmt.Println("Математика:")
	for k, v := range mathCounts {
		fmt.Printf("  %s: %.1f%%\n", k, float64(v)/n*100)
	}
	fmt.Println("Фізика:")
	for k, v := range physCounts {
		fmt.Printf("  %s: %.1f%%\n", k, float64(v)/n*100)
	}
	fmt.Println("Програмування:")
	for k, v := range progCounts {
		fmt.Printf("  %s: %.1f%%\n", k, float64(v)/n*100)
	}
}

// Пошук лідера групи, який не має оцінок "Не склав"
func getLeader(students []Student) *Student {
	var leader *Student
	for i, s := range students {
		if s.Math > 50 && s.Physics > 50 && s.Programming > 50 {
			if leader == nil || s.Average > leader.Average {
				leader = &students[i]
			}
		}
	}
	return leader
}

// Генерація лінійного графіка середніх балів студентів
func generateLinePlot(students []Student) {
	p := plot.New()
	p.Title.Text = "Середні бали студентів"
	p.X.Label.Text = "Студент"
	p.Y.Label.Text = "Середній бал"
	p.Y.Min = 0
	p.Y.Max = 100

	points := make(plotter.XYs, len(students))
	for i, s := range students {
		points[i].X = float64(i)
		points[i].Y = s.Average
	}

	line, err := plotter.NewLine(points)
	if err != nil {
		fmt.Println("Помилка створення лінії:", err)
		return
	}
	line.Color = color.RGBA{R: 0, G: 100, B: 200, A: 255}
	line.Width = vg.Points(2)
	p.Add(line)

	names := make([]string, len(students))
	for i := range students {
		names[i] = fmt.Sprintf("%d", i+1)
	}
	p.NominalX(names...)
	p.Legend.Add("Середній бал", line)

	width := vg.Length(len(students)) * 50
	if width < 400 {
		width = 400
	}
	if err := p.Save(width, 300, "average_grades.png"); err != nil {
		fmt.Println("Помилка збереження графіка:", err)
	}
}

// Генерація бар-графіка з оцінками по трьох дисциплінах
func generateBarPlot(students []Student) {
	p := plot.New()
	p.Title.Text = "Оцінки студентів по предметах"
	p.Y.Label.Text = "Бали"
	p.Y.Min = 0
	p.Y.Max = 100

	barWidth := vg.Points(20)
	gapInside := vg.Points(8)
	gapBetweenStudents := vg.Points(50)

	nameLabels := plotter.XYLabels{
		XYs:    make([]plotter.XY, len(students)),
		Labels: make([]string, len(students)),
	}
	scoreLabels := plotter.XYLabels{
		XYs:    make([]plotter.XY, 0),
		Labels: make([]string, 0),
	}

	for i, s := range students {
		values := []int{s.Math, s.Physics, s.Programming}
		subjectAbbr := []string{"М", "Ф", "П"}

		barWidthF := float64(barWidth)
		gapInsideF := float64(gapInside)
		gapBetweenF := float64(gapBetweenStudents)

		groupWidth := 3*barWidthF + 2*gapInsideF
		baseX := float64(i) * (groupWidth + gapBetweenF)

		for j, v := range values {
			x := baseX + float64(j)*(barWidthF+gapInsideF)

			bar, _ := plotter.NewBarChart(plotter.Values{float64(v)}, barWidth)
			bar.Color = getColor(v)
			bar.Offset = vg.Length(x)
			p.Add(bar)

			scoreLabels.XYs = append(scoreLabels.XYs, plotter.XY{
				X: x + float64(barWidth)/2,
				Y: float64(v) + 2,
			})
			scoreLabels.Labels = append(scoreLabels.Labels, fmt.Sprintf("%s (%d)", subjectAbbr[j], v))
		}

		nameLabels.XYs[i] = plotter.XY{
			X: baseX + groupWidth/2,
			Y: -12,
		}
		nameLabels.Labels[i] = s.Name
	}

	nameLabel, err := plotter.NewLabels(nameLabels)
	if err != nil {
		fmt.Println("Помилка створення підписів імен:", err)
		return
	}
	for i := range nameLabel.TextStyle {
		nameLabel.TextStyle[i].Color = color.Black
		nameLabel.TextStyle[i].Font.Size = 9
	}
	p.Add(nameLabel)

	scoreLabel, err := plotter.NewLabels(scoreLabels)
	if err != nil {
		fmt.Println("Помилка створення підписів балів:", err)
		return
	}
	for i := range scoreLabel.TextStyle {
		scoreLabel.TextStyle[i].Color = color.Black
		scoreLabel.TextStyle[i].Font.Size = 8
	}
	p.Add(scoreLabel)

	totalStudentsWidth := float64(len(students)) * float64(3*barWidth+2*gapInside+gapBetweenStudents)
	p.X.Min = -50
	p.X.Max = totalStudentsWidth + 50

	p.Legend.Top = true
	p.Legend.Left = false
	p.Legend.XOffs = vg.Points(10)
	p.Legend.YOffs = vg.Points(-10)

	legendBars := []struct {
		name  string
		color color.Color
	}{
		{"Не склав (0–50)", color.RGBA{255, 0, 0, 255}},
		{"Задовільно (51–70)", color.RGBA{255, 255, 0, 255}},
		{"Добре (71–89)", color.RGBA{0, 0, 255, 255}},
		{"Відмінно (90–100)", color.RGBA{0, 128, 0, 255}},
	}
	for _, lb := range legendBars {
		b, _ := plotter.NewBarChart(plotter.Values{0}, vg.Points(10))
		b.Color = lb.color
		p.Legend.Add(lb.name, b)
	}

	width := vg.Length(totalStudentsWidth) + 100
	if err := p.Save(width, 7*vg.Inch, "grades_bar.png"); err != nil {
		fmt.Println("Помилка збереження графіка:", err)
	}
}

// Визначення кольору стовпця залежно від категорії оцінки
func getColor(mark int) color.Color {
	switch {
	case mark <= 50:
		return color.RGBA{R: 255, G: 0, B: 0, A: 255}
	case mark <= 70:
		return color.RGBA{R: 255, G: 255, B: 0, A: 255}
	case mark <= 89:
		return color.RGBA{R: 0, G: 0, B: 255, A: 255}
	case mark <= 100:
		return color.RGBA{R: 0, G: 128, B: 0, A: 255}
	default:
		return color.Gray{Y: 128}
	}
}
