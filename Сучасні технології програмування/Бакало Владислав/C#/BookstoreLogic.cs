using System;
using System.Collections.Generic;
using System.Linq;

namespace BookstoreApp
{
    public class BookstoreLogic
    {
        public decimal BookPrice = 8m;
        // Базова ціна однієї книги

        public Dictionary<int, decimal> Discounts = new Dictionary<int, decimal>
        {
            {1, 0m}, {2, 0.05m}, {3, 0.10m}, {4, 0.20m}, {5, 0.25m}
            // Таблиця знижок залежно від кількості різних книг у групі
        };

        public (decimal price, List<List<int>> groups) CalculateBestPriceWithGroups(int[] books)
        {
            // Якщо кошик порожній — ціна 0 і без груп
            if (books.All(b => b == 0)) return (0m, new List<List<int>>());

            decimal minPrice = decimal.MaxValue;
            List<List<int>> bestGroups = null;

            // Перебір можливих розмірів груп від найбільшої до найменшої для кращого результату
            for (int groupSize = 5; groupSize >= 1; groupSize--)
            {
                // Перевірка: чи вистачає різних книг для групи такого розміру
                if (books.Count(b => b > 0) >= groupSize)
                {
                    int[] newBooks = (int[])books.Clone();
                    // Робимо копію масиву, щоб не змінювати оригінал

                    List<int> group = new List<int>();
                    int count = 0;

                    // Формуємо одну групу максимального розміру
                    for (int i = 0; i < newBooks.Length && count < groupSize; i++)
                    {
                        if (newBooks[i] > 0)
                        {
                            newBooks[i]--;
                            group.Add(i);
                            count++;
                        }
                    }

                    // Розрахунок ціни для групи зі знижкою
                    decimal price = groupSize * BookPrice * (1 - Discounts[groupSize]);

                    // Рекурсивно обчислюємо залишок кошика
                    var next = CalculateBestPriceWithGroups(newBooks);
                    decimal total = price + next.price;

                    // Якщо отримана ціна найменша — зберігаємо як оптимальну
                    if (total < minPrice)
                    {
                        minPrice = total;
                        bestGroups = new List<List<int>> { group };
                        bestGroups.AddRange(next.groups);
                    }
                }
            }

            return (minPrice, bestGroups ?? new List<List<int>>());
        }

        public List<string> RealWhatIfAnalysis(int[] currentBooks)
        {
            // Формує список порад "що буде якщо"
            var suggestions = new List<string>();
            var current = CalculateBestPriceWithGroups(currentBooks);
            decimal currentPrice = current.price;

            // Якщо кошик порожній — поради не потрібні
            if (currentBooks.Sum() == 0) return suggestions;

            // Аналіз різних сценаріїв користувача (цілі)
            suggestions.AddRange(AnalyzeForSpecificGoals(currentBooks, currentPrice));

            // Аналіз можливих замін книг
            suggestions.AddRange(AnalyzeSubstitutions(currentBooks, currentPrice));

            // Аналіз варіантів під конкретний бюджет
            suggestions.AddRange(AnalyzeBudgetOptions(currentBooks, currentPrice));

            return suggestions;
        }

        private List<string> AnalyzeForSpecificGoals(int[] books, decimal currentPrice)
        {
            // Сценарії цілей користувача — різні типи покупців
            var suggestions = new List<string>();

            var goals = new[]
            {
                new { Name = "Повна колекція", Target = new int[] {1,1,1,1,1}, Description = "маєте хоча б по одній книзі кожного типу" },
                new { Name = "Для читання з друзями", Target = new int[] {2,2,2,1,1}, Description = "декілька копій популярних книг" },
                new { Name = "Для бібліотеки", Target = new int[] {1,1,1,2,2}, Description = "більше книг для довготривалого зберігання" }
            };

            // Перевіряємо кожну ціль
            foreach (var goal in goals)
            {
                if (!IsGoalAchieved(books, goal.Target))
                {
                    var diff = CalculateDifference(books, goal.Target);

                    // Якщо досягти цілі потрібно небагато покупок — показуємо рекомендацію
                    if (diff.Sum() <= 3)
                    {
                        var newBasket = ApplyGoal(books, goal.Target);
                        var result = CalculateBestPriceWithGroups(newBasket);
                        decimal savings = currentPrice - result.price;

                        suggestions.Add($"{goal.Name}: {goal.Description}");
                        suggestions.Add($" -  Додати: {FormatDifference(diff)}");
                        suggestions.Add($" -  Нова ціна: {result.price:C} (зміна: {savings:-0.00;+0.00;0} ₴)");
                        suggestions.Add("");
                    }
                }
            }

            return suggestions;
        }

        private List<string> AnalyzeSubstitutions(int[] books, decimal currentPrice)
        {
            // Аналіз замін книг для оптимізації знижки
            var suggestions = new List<string>();

            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] > 0)
                {
                    for (int j = 0; j < books.Length; j++)
                    {
                        if (i != j && books[j] > 0)
                        {
                            // Пробуємо замінити одну книгу на іншу
                            int[] testBasket = (int[])books.Clone();
                            testBasket[i]--;
                            testBasket[j]++;

                            var result = CalculateBestPriceWithGroups(testBasket);
                            decimal savings = currentPrice - result.price;

                            // Якщо економія значна — рекомендуємо
                            if (savings > 0.5m)
                            {
                                suggestions.Add($"Вигідна заміна: Книга {i + 1} → Книга {j + 1}");
                                suggestions.Add($" - Економія: {savings:C} (нова ціна: {result.price:C})");
                                suggestions.Add($" - Причина: краще балансування груп");
                                suggestions.Add("");
                                break;
                            }
                        }
                    }
                }
            }

            return suggestions;
        }

        private List<string> AnalyzeBudgetOptions(int[] books, decimal currentPrice)
        {
            // Різні рівні бюджету для користувача
            var suggestions = new List<string>();
            decimal[] budgetLimits = { 30m, 50m, 70m };

            foreach (var budget in budgetLimits)
            {
                // Якщо ціна більша за бюджет — шукаємо як зменшити
                if (currentPrice > budget)
                {
                    var cheaperOption = FindCheaperOption(books, budget);
                    if (cheaperOption != null)
                    {
                        suggestions.Add($"Бюджет {budget:C}:");
                        suggestions.Add($" - Замість цього візьміть: {cheaperOption}");
                        suggestions.Add("");
                    }
                }
                // Якщо є запас бюджету — пропонуємо покращення
                else if (currentPrice < budget * 0.8m)
                {
                    var betterOption = FindBetterOption(books, budget);
                    if (betterOption != null)
                    {
                        suggestions.Add($"Ваш бюджет до {budget:C}:");
                        suggestions.Add($" - Кращий варіант: {betterOption}");
                        suggestions.Add("");
                    }
                }
            }

            return suggestions;
        }

        private bool IsGoalAchieved(int[] current, int[] target)
        {
            // Перевіряє, чи кошик відповідає вимогам цілі
            return current.Zip(target, (c, t) => c >= t).All(x => x);
        }

        private int[] CalculateDifference(int[] current, int[] target)
        {
            // Які книги потрібно додати, щоб досягти цілі
            return target.Zip(current, (t, c) => Math.Max(0, t - c)).ToArray();
        }

        private int[] ApplyGoal(int[] current, int[] target)
        {
            // Формує новий кошик згідно з ціллю
            return current.Zip(target, (c, t) => Math.Max(c, t)).ToArray();
        }

        private string FormatDifference(int[] diff)
        {
            // Текстовий опис, які книги треба додати
            var changes = diff.Select((d, i) => d > 0 ? $"+{d} до книги {i + 1}" : "")
                             .Where(s => !string.IsNullOrEmpty(s));
            return string.Join(", ", changes);
        }

        private string FindCheaperOption(int[] books, decimal budget)
        {
            // Спрощений варіант: пробуємо зменшити кожну книгу по одній
            int[] testBasket = (int[])books.Clone();

            for (int i = 0; i < books.Length; i++)
            {
                if (testBasket[i] > 0)
                {
                    testBasket[i]--;
                    var price = CalculateBestPriceWithGroups(testBasket).price;

                    if (price <= budget)
                        return $"Книга {i + 1}: {testBasket[i]} шт. (ціна: {price:C})";

                    testBasket[i]++;
                }
            }

            return null;
        }

        private string FindBetterOption(int[] books, decimal budget)
        {
            // Пробуємо додати по одній книзі, поки не вичерпаємо бюджет
            int[] testBasket = (int[])books.Clone();

            for (int i = 0; i < books.Length; i++)
            {
                testBasket[i]++;
                var price = CalculateBestPriceWithGroups(testBasket).price;

                if (price <= budget)
                    return $"додати книгу {i + 1} (ціна: {price:C})";

                testBasket[i]--;
            }

            return null;
        }
    }
}
