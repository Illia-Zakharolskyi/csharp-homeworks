using System;
using OOPLearning.Application.Formatters;
using OOPLearning.Classes;

namespace OOPLearning.Application.Runners;

internal static class DemoRunner
{
    internal static void RunAllDemos()
    {
        List<Action> allDemos = new()
        {
            RunBankAccountDemo,
            RunEnemyDemo,
            RunMagicDemo,
            RunTreausreChestDemo,
            RunInventoryDemo,
            RunMedicinalPlantDemo,
            RunTrapDemo,
            RunKnightSwordDemo,
            RunRecipeDemo,
        };
        
        Console.WriteLine(new string('~', 15) + " Початок усіх демонстрацій " + new string('~', 15));
        Console.WriteLine();
        RunDemoClassesFormatter.RunActions(allDemos, "Демонстрація", '*', 70);
        Console.WriteLine();
        Console.WriteLine(new string('~', 15) + " Кінець усіх демонстрацій " + new string('~', 15));
    }
    internal static void RunBankAccountDemo()
    {
        BankAccount account = new BankAccount()
        {
            OwnerName = "Іван Петренко"
        };

        var actions = new List<Action>
        {
            () => account.ShowAccountInfo(),
            () => account.DepositMoney(1500m),
            () => account.ShowAccountInfo(),
            () => account.WithdrawMoney(500m),
            () => account.ShowAccountInfo(),
            () => account.WithdrawMoney(2000m),
            () => account.ShowAccountInfo()
        };

        Console.WriteLine(new string('=', 10) + " Початок презентації дій з банківським рахунком " + new string('=', 10));
        Console.WriteLine();
        RunDemoClassesFormatter.RunActions(actions, "Дія з банківським рахунком", '-', 50);
        Console.WriteLine();
        Console.WriteLine(new string('=', 10) + " Кінець презентації дій з банківським рахунком " + new string('=', 10));
    }
    internal static void RunEnemyDemo() 
    {
        Enemy goblin = new Enemy()
        {
            Name = "Гоблін",
            MaxHealth = 30f,
            BaseAttackPower = 6f
        };
        Enemy skeleton = new Enemy()
        {
            Name = "Скелет",
            MaxHealth = 25f,
            BaseAttackPower = 8f
        };

        List<Action> actions = new()
        {
            () => goblin.AttackTarget(skeleton),
            () => skeleton.AttackTarget(goblin),
            () => goblin.AttackTarget(skeleton),
            () => goblin.LevelUp(), 
            () => skeleton.Heal(10),
            () => skeleton.AttackTarget(goblin), 
            () => goblin.AttackTarget(skeleton), 
            () => skeleton.AttackTarget(goblin), 
            () => skeleton.LevelUp(), 
            () => goblin.AttackTarget(skeleton), 
            () => skeleton.AttackTarget(goblin), 
            () => goblin.Heal(2), 
            () => skeleton.AttackTarget(goblin), 
            () => goblin.AttackTarget(skeleton), 
            () => skeleton.AttackTarget(goblin)
        };

        goblin.ShowInfoByCreation();
        skeleton.ShowInfoByCreation();

        Console.WriteLine(new string('=', 5) + " Початок битви! " + new string('=', 5));
        Console.WriteLine();

        RunDemoClassesFormatter.RunActions(actions, "Хід", '-', 90);

        Console.WriteLine();
        Console.WriteLine(new string('=', 5) + " Кінець битви! " + new string('=', 5));

        Console.WriteLine($"Переможець: {(goblin.IsAlive ? goblin.Name : skeleton.Name)}");
    }
    internal static void RunMagicDemo()
    {
        Magic magic = new Magic();
        magic.CastSpell("Вогняна куля");
        magic.UsePotion("Зілля здоров'я");
    }
    internal static void RunTreausreChestDemo()
    {
        TreasureChest chest = new TreasureChest();

        var actions = new List<Action>
        {
            () => chest.OpenChest(),
            () => chest.CloseChest(),
            () => chest.AddTreasure("Золото", 6),
            () => chest.AddTreasure("Діаманти", 3),
            () => chest.OpenChest(),
            () => chest.AddTreasure("Золото", 4),
            () => chest.OpenChest(),
            () => chest.CloseChest(),
            () => chest.OpenChest(),
            () => chest.CloseChest(),
            () => chest.CloseChest(),
        };

        Console.WriteLine(new string('=', 10) + " Початок презентації дій зі скринею " + new string('=', 10));
        Console.WriteLine();
        RunDemoClassesFormatter.RunActions(actions, "Дія зі скринею", '-', 50);
        Console.WriteLine();
        Console.WriteLine(new string('=', 10) + " Кінець презентації дій зі скринею " + new string('=', 10));
    }
    internal static void RunInventoryDemo()
    {
        Inventory inventory = new Inventory();

        List<Action> actions = new()
        {
            () => inventory.ShowInventory(),
            () => inventory.AddItem("Меч"),
            () => inventory.AddItem("Щит", 2),
            () => inventory.ShowInventory(),
            () => inventory.AddItem("Меч", 3),
            () => inventory.ShowInventory(),
            () => inventory.RemoveItem("Лук"),
            () => inventory.RemoveItem("Щит"),
            () => inventory.ShowInventory(),
            () => inventory.ClearInvenory(),
            () => inventory.ShowInventory()
        };

        Console.WriteLine(new string('=', 10) + " Початок презентації дій з Інвентаром " + new string('=', 10));
        Console.WriteLine();
        RunDemoClassesFormatter.RunActions(actions, "Дія з Інвентарем", '-', 50);
        Console.WriteLine();
        Console.WriteLine(new string('=', 10) + " Кінець презентації дій з Інвентарем " + new string('=', 10));
    }
    internal static void RunMedicinalPlantDemo()
    {
        MedicinalPlant plantCollector = new MedicinalPlant();

        List<Action> actions = new()
        {
            () => plantCollector.ShowCollectedPlants(),
            () => plantCollector.CollectPlant("Ромашка", 3),
            () => plantCollector.CollectPlant("М'ята", 5),
            () => plantCollector.ShowCollectedPlants(),
            () => plantCollector.CollectPlant("Алоє", 4),
            () => plantCollector.ShowCollectedPlants(),
            () => plantCollector.CreateMedicine("зілля відновлення мани"),
            () => plantCollector.CreateMedicine("зілля лікування"),
            () => plantCollector.CreateMedicine("зілля сили"),
            () => plantCollector.CreateMedicine("зілля невідоме")
        };

        Console.WriteLine(new string('=', 10) + " Початок презентації дій зі збором лікарських рослин " + new string('=', 10));
        Console.WriteLine();
        RunDemoClassesFormatter.RunActions(actions, "Дія зі збором лікарських рослин", '-', 70);
        Console.WriteLine();
        Console.WriteLine(new string('=', 10) + " Кінець презентації дій зі збором лікарських рослин " + new string('=', 10));
    }
    internal static void RunTrapDemo()
    {
        Trap trap = new Trap();
        var actions = new List<Action>
        {
            () => trap.TriggerTrap(),
            () => trap.ResetTrap(),
            () => trap.TriggerTrap(),
            () => trap.TriggerTrap(),
            () => trap.ResetTrap(),
            () => trap.ResetTrap()
        };

        Console.WriteLine(new string('=', 10) + " Початок презентації дій з пасткою " + new string('=', 10));
        Console.WriteLine();
        RunDemoClassesFormatter.RunActions(actions, "Дія з пасткою", '-', 50);
        Console.WriteLine();
        Console.WriteLine(new string('=', 10) + " Кінець презентації дій з пасткою " + new string('=', 10));
    }
    internal static void RunKnightSwordDemo()
    {
        KnightSword knightSword = new KnightSword()
        {
            SwordOwner = "Герой",
            BaseAttackPower = 35,
            BaseDurability = 50
        };
        Enemy enemy1 = new Enemy()
        {
            Name = "Огр",
            MaxHealth = 50f,
            BaseAttackPower = 10f
        };
        Enemy enemy2 = new Enemy()
        {
            Name = "Троль",
            MaxHealth = 60f,
            BaseAttackPower = 12f
        };

        var actions = new List<Action>
        {
            () => knightSword.Attack(enemy1),
            () => knightSword.ShowSwordDurability(),
            () => knightSword.Attack(enemy2),
            () => knightSword.ShowSwordDurability(),
            () => knightSword.UpgradeSword(),
            () => knightSword.ShowSwordDurability(),
            () => knightSword.Attack(enemy2),
            () => knightSword.ShowSwordDurability(),
            () => knightSword.Attack(enemy1),
            () => knightSword.UpgradeSword(),
            () => knightSword.Attack(enemy2),
            () => knightSword.ShowSwordDurability()
        };

        knightSword.ShowSwordInfo();

        Console.WriteLine(new string('=', 10) + " Початок презентації дій з мечем лицаря " + new string('=', 10));
        Console.WriteLine();
        RunDemoClassesFormatter.RunActions(actions, "Дія з мечем лицаря", '-', 50);
        Console.WriteLine();
        Console.WriteLine(new string('=', 10) + " Кінець презентації дій з мечем лицаря " + new string('=', 10));
    }
    internal static void RunRecipeDemo()
    {
        Recipe recipe = new Recipe()
        {
            Name = "Оладки на кефірі"
        };

        var actions = new List<Action>
        {
            () => recipe.ShowRecipeIngredients(),
            () => recipe.AddIngredient("Кефір", "251 мл."),
            () => recipe.ChangeIngredientQuantity("Кафір", "250 мл."),
            () => recipe.ChangeIngredientQuantity("Кефір", "250 мл."),
            () => recipe.ShowRecipeIngredients(),
            () => recipe.AddIngredient("Борошно", "350 г."),
            () => recipe.AddIngredient("Яйця"),
            () => recipe.AddIngredient("Цукор", "1.5 ст.л"),
            () => recipe.AddIngredient("Сіль", "1/3 ст.л"),
            () => recipe.AddIngredient("Сода", "1/2 ст.л"),
            () => recipe.ShowRecipeIngredients(),
            () => recipe.RemoveIngredient("Кеффр"),
            () => recipe.RemoveIngredient("Кефір"),
            () => recipe.ShowRecipeIngredients()
        };

        Console.WriteLine(new string('=', 10) + " Початок презентації дій з рецептом " + new string('=', 10));
        Console.WriteLine();
        RunDemoClassesFormatter.RunActions(actions, "Дія з рецептом", '-', 50);
        Console.WriteLine();
        Console.WriteLine(new string('=', 10) + " Кінець презентації дій з рецептом " + new string('=', 10));
    }
    internal static void RunExitDemo()
    {
        Environment.Exit(0);
    }
}