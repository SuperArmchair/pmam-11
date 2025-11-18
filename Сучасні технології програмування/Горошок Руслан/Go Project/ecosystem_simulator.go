package main

import (
	"fmt"
	"math/rand"
	"sync"
	"time"
)

type EntityType string

const (
	Plant     EntityType = "Plant"
	Herbivore EntityType = "Herbivore"
	Predator  EntityType = "Predator"
)

type Entity struct {
	ID       string
	Type     EntityType
	X, Y     int
	Alive    bool
	QuitCh   chan bool
	Moves    int
	Consumed int
}

var (
	entities      = make(map[string]*Entity)
	mutex         sync.Mutex
	MapWidth      int
	MapHeight     int
	wg            sync.WaitGroup
	lastAnalytics Analytics
)

type Analytics struct {
	CountAlive    map[EntityType]int
	CountDead     map[EntityType]int
	TotalMoves    map[EntityType]int
	TotalConsumed map[EntityType]int
}

func moveEntity(e *Entity) {
	defer wg.Done()
	for {
		select {
		case <-e.QuitCh:
			return
		case <-time.After(time.Duration(300+rand.Intn(700)) * time.Millisecond):
			mutex.Lock()
			if !e.Alive {
				mutex.Unlock()
				return
			}
			e.X = clamp(e.X+rand.Intn(3)-1, 0, MapWidth-1)
			e.Y = clamp(e.Y+rand.Intn(3)-1, 0, MapHeight-1)
			e.Moves++

			for _, other := range entities {
				if !other.Alive {
					continue
				}
				if e.Type == Herbivore && other.Type == Plant && e.X == other.X && e.Y == other.Y {
					other.Alive = false
					e.Consumed++
				}
				if e.Type == Predator && other.Type == Herbivore && e.X == other.X && e.Y == other.Y {
					other.Alive = false
					e.Consumed++
				}
			}
			mutex.Unlock()
		}
	}
}

func clamp(val, min, max int) int {
	if val < min {
		return min
	}
	if val > max {
		return max
	}
	return val
}

func drawMap() {
	mutex.Lock()
	defer mutex.Unlock()

	grid := make([][]string, MapHeight)
	for i := range grid {
		grid[i] = make([]string, MapWidth)
		for j := range grid[i] {
			grid[i][j] = "."
		}
	}

	for _, e := range entities {
		if e.Alive {
			switch e.Type {
			case Plant:
				grid[e.Y][e.X] = "*"
			case Herbivore:
				grid[e.Y][e.X] = "H"
			case Predator:
				grid[e.Y][e.X] = "P"
			}
		}
	}

	fmt.Print("\033[H\033[2J")
	fmt.Println("==== ECOSYSTEM SIMULATOR ====")
	for _, row := range grid {
		for _, cell := range row {
			fmt.Print(cell, " ")
		}
		fmt.Println()
	}
	fmt.Println("Legend: *=Plant, H=Herbivore, P=Predator")
	fmt.Println("=============================")
	fmt.Println("Press ENTER to stop simulation...")
}

func addEntity(id string, typ EntityType, x, y int) {
	mutex.Lock()
	defer mutex.Unlock()
	if _, exists := entities[id]; exists {
		fmt.Println("Entity with this ID already exists!")
		return
	}
	e := &Entity{ID: id, Type: typ, X: x, Y: y, Alive: true, QuitCh: make(chan bool)}
	entities[id] = e
	wg.Add(1)
	go moveEntity(e)
	fmt.Println("Added entity:", id)
}

func addEntityInteractive() {
	var id, typ string
	var x, y int
	fmt.Print("Enter ID: ")
	fmt.Scan(&id)
	fmt.Print("Enter Type (Plant/Herbivore/Predator): ")
	fmt.Scan(&typ)
	fmt.Print("Enter X (0-", MapWidth-1, "): ")
	fmt.Scan(&x)
	fmt.Print("Enter Y (0-", MapHeight-1, "): ")
	fmt.Scan(&y)

	var eType EntityType
	switch typ {
	case "Plant":
		eType = Plant
	case "Herbivore":
		eType = Herbivore
	case "Predator":
		eType = Predator
	default:
		fmt.Println("Invalid type!")
		return
	}
	addEntity(id, eType, x, y)
}

func autoAddEntities() {
	types := []EntityType{Plant, Herbivore, Predator}
	for i := 0; i < 10; i++ {
		id := fmt.Sprintf("E%d", i+1)
		addEntity(id, types[rand.Intn(len(types))], rand.Intn(MapWidth), rand.Intn(MapHeight))
	}
}

func collectAnalytics() Analytics {
	mutex.Lock()
	defer mutex.Unlock()
	a := Analytics{
		CountAlive:    map[EntityType]int{},
		CountDead:     map[EntityType]int{},
		TotalMoves:    map[EntityType]int{},
		TotalConsumed: map[EntityType]int{},
	}
	for _, e := range entities {
		if e.Alive {
			a.CountAlive[e.Type]++
		} else {
			a.CountDead[e.Type]++
		}
		a.TotalMoves[e.Type] += e.Moves
		a.TotalConsumed[e.Type] += e.Consumed
	}
	return a
}

func showAnalytics(a Analytics) {
	fmt.Println("\n==== SIMULATION ANALYTICS ====")
	fmt.Printf("%-10s | Alive | Dead | Moves | Consumed\n", "Type")
	for _, t := range []EntityType{Plant, Herbivore, Predator} {
		fmt.Printf("%-10s | %-5d | %-4d | %-5d | %-8d\n",
			t, a.CountAlive[t], a.CountDead[t], a.TotalMoves[t], a.TotalConsumed[t])
	}
	fmt.Println("================================")
}

func startSimulation() {
	if len(entities) == 0 {
		fmt.Println("No entities on map! Please add entities first.")
		return
	}
	ticker := time.NewTicker(500 * time.Millisecond)
	defer ticker.Stop()
	done := make(chan struct{})
	go func() { fmt.Scanln(); close(done) }()

loop:
	for {
		select {
		case <-ticker.C:
			drawMap()
		case <-done:
			break loop
		}
	}

	mutex.Lock()
	quitChannels := make([]chan bool, 0, len(entities))
	for _, e := range entities {
		quitChannels = append(quitChannels, e.QuitCh)
	}
	mutex.Unlock()

	for _, ch := range quitChannels {
		select {
		case ch <- true:
		default:
		}
	}
	wg.Wait()
	lastAnalytics = collectAnalytics()
	drawMap()
	showAnalytics(lastAnalytics)
}

func mainMenu() {
	for {
		fmt.Println("\n==== ECOSYSTEM MENU ====")
		fmt.Println("1. Set Map Size")
		fmt.Println("2. Add Entity Manually")
		fmt.Println("3. Auto Add Entities")
		fmt.Println("4. Start Simulation")
		fmt.Println("5. Show Last Simulation Analytics")
		fmt.Println("6. Exit")
		fmt.Print("Choose option: ")
		var choice int
		fmt.Scan(&choice)
		switch choice {
		case 1:
			fmt.Print("Enter Map Width: ")
			fmt.Scan(&MapWidth)
			fmt.Print("Enter Map Height: ")
			fmt.Scan(&MapHeight)
			fmt.Println("Map size set to", MapWidth, "x", MapHeight)
		case 2:
			if MapWidth == 0 || MapHeight == 0 {
				fmt.Println("Set map size first!")
			} else {
				addEntityInteractive()
			}
		case 3:
			if MapWidth == 0 || MapHeight == 0 {
				fmt.Println("Set map size first!")
			} else {
				autoAddEntities()
			}
		case 4:
			if MapWidth == 0 || MapHeight == 0 {
				fmt.Println("Set map size first!")
			} else {
				startSimulation()
			}
		case 5:
			if lastAnalytics.CountAlive == nil {
				fmt.Println("No simulation has been run yet.")
			} else {
				showAnalytics(lastAnalytics)
			}
		case 6:
			fmt.Println("Exiting...")
			return
		default:
			fmt.Println("Invalid choice!")
		}
	}
}

func main() {
	rand.Seed(time.Now().UnixNano())
	mainMenu()
}
