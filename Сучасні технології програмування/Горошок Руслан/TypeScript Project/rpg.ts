console.log("Ласкаво просимо у Консольну RPG гру!\n");

class Weapon {
    name: string;
    minDamage: number;
    maxDamage: number;
    price: number;

    constructor(name: string, minDamage: number, maxDamage: number, price: number) {
        this.name = name;
        this.minDamage = minDamage;
        this.maxDamage = maxDamage;
        this.price = price;
    }
}

class Armor {
    name: string;
    defense: number;
    price: number;

    constructor(name: string, defense: number, price: number) {
        this.name = name;
        this.defense = defense;
        this.price = price;
    }
}

class Potion {
    name: string;
    healAmount: number;
    price: number;

    constructor(name: string, healAmount: number, price: number) {
        this.name = name;
        this.healAmount = healAmount;
        this.price = price;
    }
}

class Player {
    name: string;
    health: number;
    maxHealth: number;
    gold: number;
    weapon: Weapon;
    armor: Armor;
    inventory: (Weapon | Armor | Potion)[] = [];
    level: number = 1;
    experience: number = 0;
    statPoints: number = 0;
    strength: number = 5;
    luck: number = 1;

    constructor(name: string) {
        this.name = name;
        this.health = 100;
        this.maxHealth = 100;
        this.gold = 0;
        this.weapon = new Weapon("Дерев'яний меч", 5, 10, 0);
        this.armor = new Armor("Тканинна броня", 0, 0);
        this.inventory.push(this.weapon, this.armor);
    }

    isAlive(): boolean {
        return this.health > 0;
    }

    attackDamage(): number {
        return randomInt(this.weapon.minDamage + this.strength, this.weapon.maxDamage + this.strength);
    }

    takeDamage(amount: number) {
        const damageTaken = Math.max(0, amount - this.armor.defense);
        this.health -= damageTaken;
        return damageTaken;
    }

    gainExperience(exp: number) {
        this.experience += exp;
        while (this.experience >= this.level * 50) {
            this.experience -= this.level * 50;
            this.levelUp();
        }
    }

    levelUp() {
        this.level++;
        this.statPoints += 3;
        this.maxHealth += 10;
        this.health = this.maxHealth;
        console.log(`Ти досяг рівня ${this.level}. Тобі доступні 3 очки характеристик.`);
        distributeStats(this);
    }
}

class Monster {
    name: string;
    health: number;
    damage: number;
    expReward: number;

    constructor(name: string, health: number, damage: number, expReward: number) {
        this.name = name;
        this.health = health;
        this.damage = damage;
        this.expReward = expReward;
    }

    isAlive(): boolean {
        return this.health > 0;
    }
}

function randomInt(min: number, max: number): number {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

const monsters = [
    new Monster("Гоблін", 30, 10, 20),
    new Monster("Скелет", 20, 15, 15),
    new Monster("Тролль", 50, 20, 50)
];

const shopWeapons = [
    new Weapon("Залізний меч", 10, 20, 50),
    new Weapon("Срібний меч", 15, 25, 100),
    new Weapon("Магічний меч", 20, 35, 200)
];

const shopArmor = [
    new Armor("Залізна броня", 5, 50),
    new Armor("Срібна броня", 10, 100),
    new Armor("Магічна броня", 15, 200)
];

const shopPotions = [
    new Potion("Мале зілля", 20, 20),
    new Potion("Середнє зілля", 50, 50),
    new Potion("Велике зілля", 100, 100)
];

let player: Player | null = null;

function mainMenu(): void {
    console.log("\n=== Головне меню ===");
    console.log("1. Почати нову гру");
    console.log("2. Правила гри");
    console.log("3. Вийти");

    const choice = prompt("Введи номер опції:") || "";
    switch(choice) {
        case "1": startGame(); break;
        case "2": showRules(); break;
        case "3": console.log("Дякуємо за гру. До зустрічі!"); break;
        default: console.log("Невірна опція."); mainMenu();
    }
}

function showRules(): void {
    console.log("\n=== Правила гри ===");
    console.log("1. Ти досліджуєш підземелля, зустрічаєш монстрів і знаходиш скарби.");
    console.log("2. У бою ти можеш бити монстра, тікати або використати зілля.");
    console.log("3. Можна отримувати нову зброю і броню від монстрів або купляти в магазині.");
    console.log("4. Збирай досвід та підвищуй рівень, розподіляй очки характеристик.");
    console.log("5. Мета: вижити і накопичити золото.\n");
    mainMenu();
}

function startGame(): void {
    const playerName = prompt("Введи своє ім'я:") || "Герой";
    player = new Player(playerName);
    console.log(`Привіт, ${player.name}! Здоров'я: ${player.health}, золото: ${player.gold}, зброя: ${player.weapon.name}, броня: ${player.armor.name}`);
    nextAction();
}

function viewProfile(): void {
    if (!player) return;
    console.log("\n=== Профіль героя ===");
    console.log(`Ім'я: ${player.name}`);
    console.log(`Рівень: ${player.level} (Досвід: ${player.experience}/${player.level * 50})`);
    console.log(`Здоров'я: ${player.health}/${player.maxHealth}`);
    console.log(`Сила: ${player.strength}`);
    console.log(`Вдача: ${player.luck}`);
    console.log(`Золото: ${player.gold}`);
    console.log(`Зброя: ${player.weapon.name} (Шкода: ${player.weapon.minDamage}-${player.weapon.maxDamage})`);
    console.log(`Броня: ${player.armor.name} (Захист: ${player.armor.defense})`);
    console.log("=== Інвентар ===");
    player.inventory.forEach((item, i) => {
        if (item instanceof Weapon) console.log(`${i+1}. ${item.name} (Шкода: ${item.minDamage}-${item.maxDamage})`);
        else if (item instanceof Armor) console.log(`${i+1}. ${item.name} (Захист: ${item.defense})`);
        else if (item instanceof Potion) console.log(`${i+1}. ${item.name} (Відновлює: ${item.healAmount})`);
    });
    nextAction();
}

function distributeStats(p: Player) {
    while (p.statPoints > 0) {
        console.log(`У тебе ${p.statPoints} очки для розподілу.`);
        console.log("1. Здоров'я\n2. Сила\n3. Вдача");
        const choice = prompt("Що підвищуємо? (1/2/3)") || "";
        switch(choice) {
            case "1": p.maxHealth += 5; p.health = p.maxHealth; p.statPoints--; console.log("Здоров'я збільшено."); break;
            case "2": p.strength += 2; p.statPoints--; console.log("Сила збільшена."); break;
            case "3": p.luck += 1; p.statPoints--; console.log("Вдача збільшена."); break;
            default: console.log("Невірна характеристика."); break;
        }
    }
}

function explore(): void {
    if (!player) return;
    console.log("Ти йдеш темними підземеллями...\n");
    const event = randomInt(1, 3);
    if (event === 1) {
        const monster = monsters[randomInt(0, monsters.length - 1)];
        console.log(`Ти зустрів ${monster.name}!`);
        fight(monster);
    } else if (event === 2) {
        const goldFound = randomInt(10, 50);
        player.gold += goldFound;
        console.log(`Ти знайшов скарб! Отримав ${goldFound} золота. Разом золота: ${player.gold}`);
        nextAction();
    } else {
        console.log("Порожня кімната. Нічого цікавого...");
        nextAction();
    }
}

function fight(monster: Monster): void {
    if (!player) return;

    while (monster.isAlive() && player.isAlive()) {
        console.log(`\n=== Бій з ${monster.name} ===`);
        console.log(`Твоє здоров'я: ${player.health}/${player.maxHealth}`);
        console.log(`Здоров'я монстра: ${monster.health}`);
        console.log("1. Бити");
        console.log("2. Використати зілля");
        console.log("3. Тікати");

        const choice = Number(prompt("Введи номер дії:") || "0");

        switch(choice) {
            case 1:
                const playerDamage = player.attackDamage();
                monster.health -= playerDamage;
                console.log(`Ти наніс ${playerDamage} шкоди ${monster.name}.`);
                break;

            case 2:
                const potions = player.inventory.filter(i => i instanceof Potion) as Potion[];
                if (potions.length === 0) { console.log("У тебе немає зілля!"); continue; }
                console.log("Вибери зілля для використання:");
                potions.forEach((p, i) => console.log(`${i+1}. ${p.name} (Відновлює: ${p.healAmount})`));
                const potionChoice = Number(prompt("Введи номер зілля:") || "0") - 1;
                if (potionChoice >= 0 && potionChoice < potions.length) {
                    const potion = potions[potionChoice];
                    player.health = Math.min(player.maxHealth, player.health + potion.healAmount);
                    player.inventory.splice(player.inventory.indexOf(potion), 1);
                    console.log(`Ти використав ${potion.name}. Здоров'я: ${player.health}/${player.maxHealth}`);
                } else console.log("Невірний вибір.");
                break;

            case 3:
                const escapeSuccess = randomInt(1, 2) === 1;
                if (escapeSuccess) {
                    console.log("Тобі вдалося втекти!");
                    const partialExp = Math.floor(monster.expReward / 2);
                    const partialGold = Math.floor(randomInt(5, 15));
                    player.gainExperience(partialExp);
                    player.gold += partialGold;
                    console.log(`Ти отримав частковий досвід: ${partialExp} і золото: ${partialGold}`);
                    nextAction();
                    return;
                } else console.log("Не вдалося втекти!");
                break;

            default:
                console.log("Невірний вибір. Введи цифру 1, 2 або 3.");
                continue;
        }

        if (monster.isAlive()) {
            const damageTaken = player.takeDamage(monster.damage);
            console.log(`${monster.name} атакує! Ти втратив ${damageTaken} здоров'я. Твоє здоров'я: ${Math.max(player.health, 0)}`);
        }
    }

    if (!player.isAlive()) { console.log("Ти програв... Гру завершено."); mainMenu(); return; }

    if (!monster.isAlive()) {
        const goldLoot = randomInt(10, 30);
        player.gold += goldLoot;
        player.gainExperience(monster.expReward);
        console.log(`Ти переміг ${monster.name}! Отримав ${goldLoot} золота та ${monster.expReward} досвіду.`);

        if (randomInt(1, 2) === 1) {
            const newWeapon = new Weapon("Кам'яний меч", 8, 15, 0);
            player.inventory.push(newWeapon);
            console.log(`Монстр кинув зброю! Ти отримав ${newWeapon.name}.`);
        } else {
            const newArmor = new Armor("Кам'яна броня", 3, 0);
            player.inventory.push(newArmor);
            console.log(`Монстр кинув броню! Ти отримав ${newArmor.name}.`);
        }

        nextAction();
    }
}

function visitShop(): void {
    if (!player) return;
    console.log("\n=== Магазин ===");
    console.log("1. Купити зброю");
    console.log("2. Купити броню");
    console.log("3. Купити зілля");
    console.log("0. Вихід");

    const choice = prompt("Введи номер опції:") || "";
    switch(choice) {
        case "1": buyWeapon(); break;
        case "2": buyArmor(); break;
        case "3": buyPotion(); break;
        case "0": nextAction(); break;
        default: console.log("Невірна команда."); visitShop();
    }
}

function buyWeapon(): void {
    if (!player) return;
    shopWeapons.forEach((w, i) => console.log(`${i+1}. ${w.name} (Шкода: ${w.minDamage}-${w.maxDamage}) - ${w.price} золота`));
    console.log("0. Вихід");
    const choice = Number(prompt("Введи номер зброї для покупки:") || "0");
    if (choice === 0) { visitShop(); return; }
    const weapon = shopWeapons[choice-1];
    if (player.gold >= weapon.price) {
        player.gold -= weapon.price;
        player.inventory.push(weapon);
        player.weapon = weapon;
        console.log(`Ти купив ${weapon.name} і тепер ця зброя активна.`);
    } else console.log("Недостатньо золота!");
    buyWeapon();
}

function buyArmor(): void {
    if (!player) return;
    shopArmor.forEach((a, i) => console.log(`${i+1}. ${a.name} (Захист: ${a.defense}) - ${a.price} золота`));
    console.log("0. Вихід");
    const choice = Number(prompt("Введи номер броні для покупки:") || "0");
    if (choice === 0) { visitShop(); return; }
    const armor = shopArmor[choice-1];
    if (player.gold >= armor.price) {
        player.gold -= armor.price;
        player.inventory.push(armor);
        player.armor = armor;
        console.log(`Ти купив ${armor.name} і тепер ця броня активна.`);
    } else console.log("Недостатньо золота!");
    buyArmor();
}

function buyPotion(): void {
    if (!player) return;
    shopPotions.forEach((p, i) => console.log(`${i+1}. ${p.name} (Відновлює: ${p.healAmount}) - ${p.price} золота`));
    console.log("0. Вихід");
    const choice = Number(prompt("Введи номер зілля для покупки:") || "0");
    if (choice === 0) { visitShop(); return; }
    const potion = shopPotions[choice-1];
    if (player.gold >= potion.price) {
        player.gold -= potion.price;
        player.inventory.push(potion);
        console.log(`Ти купив ${potion.name}.`);
    } else console.log("Недостатньо золота!");
    buyPotion();
}

function equipWeapon(): void {
    if (!player) return;
    const weapons = player.inventory.filter(i => i instanceof Weapon) as Weapon[];
    if (weapons.length === 0) {
        console.log("У тебе немає зброї в інвентарі.");
        nextAction();
        return;
    }
    console.log("=== Вибір зброї ===");
    weapons.forEach((w, i) => console.log(`${i+1}. ${w.name} (Шкода: ${w.minDamage}-${w.maxDamage})`));
    console.log("0. Вихід");
    const choice = Number(prompt("Введи номер зброї для одiти:") || "0");
    if (choice === 0) { nextAction(); return; }
    if (choice > 0 && choice <= weapons.length) {
        player.weapon = weapons[choice - 1];
        console.log(`Ти одiв ${player.weapon.name}.`);
    } else console.log("Невірний вибір.");
    nextAction();
}

function equipArmor(): void {
    if (!player) return;
    const armors = player.inventory.filter(i => i instanceof Armor) as Armor[];
    if (armors.length === 0) {
        console.log("У тебе немає броні в інвентарі.");
        nextAction();
        return;
    }
    console.log("=== Вибір броні ===");
    armors.forEach((a, i) => console.log(`${i+1}. ${a.name} (Захист: ${a.defense})`));
    console.log("0. Вихід");
    const choice = Number(prompt("Введи номер броні для одiти:") || "0");
    if (choice === 0) { nextAction(); return; }
    if (choice > 0 && choice <= armors.length) {
        player.armor = armors[choice - 1];
        console.log(`Ти одiв ${player.armor.name}.`);
    } else console.log("Невірний вибір.");
    nextAction();
}

function nextAction(): void {
    if (!player || !player.isAlive()) { mainMenu(); return; }

    console.log("\n=== Наступна дія ===");
    console.log("1. Досліджувати підземелля");
    console.log("2. Переглянути профіль");
    console.log("3. Магазин");
    console.log("4. Одiти зброю");
    console.log("5. Одiти броню");
    console.log("0. Вийти в головне меню");

    const choice = prompt("Введи номер дії:") || "";
    switch(choice) {
        case "1": explore(); break;
        case "2": viewProfile(); break;
        case "3": visitShop(); break;
        case "4": equipWeapon(); break;
        case "5": equipArmor(); break;
        case "0": mainMenu(); break;
        default: console.log("Невірна команда."); nextAction();
    }
}

mainMenu();
