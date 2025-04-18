SET IDENTITY_INSERT Players ON;
INSERT INTO Players (Id, Name, Health, Experience)
VALUES
    (1, 'Sir Lancelot', 100, 0);
SET IDENTITY_INSERT Players OFF;

SET IDENTITY_INSERT Inventories ON;
INSERT INTO Inventories (Id, Gold, Capacity, PlayerId)
VALUES
    (1, 100, 10, 1);
SET IDENTITY_INSERT Inventories OFF;

SET IDENTITY_INSERT Monsters ON;
INSERT INTO Monsters (Id, Name, MonsterType, Health, AggressionLevel, Sneakiness)
VALUES
    (1, 'Bob Goblin', 'Goblin', 175, 10, 3);
SET IDENTITY_INSERT Monsters OFF;

SET IDENTITY_INSERT Abilities ON;
INSERT INTO Abilities (Id, Name, Description, AbilityType, Damage, Distance)
VALUES
    (1, 'Shove', 'Power Shove', 'ShoveAbility', 10, 5);
SET IDENTITY_INSERT Abilities OFF;

SET IDENTITY_INSERT Items ON;
INSERT INTO Items (Id, Name, Value, Description, InventoryId, ItemType, AttackPower, DefensePower, Durability)
VALUES
    (1, 'Starter Sword', 5.0, 'A basic sword', 1, 'Weapon', 5, 0, 10),
    (2, 'Wooden Shield', 3.0, 'A cheap shield', 1, 'Armor', 0, 3, 4),
    (3, 'Rusty Dagger', 0.7, 'A rusting dagger', 1, 'Weapon', 2, 0, 3),
    (4, 'Leather Armor', 4.0, 'Basic leather armor', 1, 'Armor', 0, 5, 10);
SET IDENTITY_INSERT Items OFF;


INSERT INTO PlayerAbilities (PlayersId, AbilitiesId)
VALUES
    (1, 1); 
