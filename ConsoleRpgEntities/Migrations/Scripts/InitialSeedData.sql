SET IDENTITY_INSERT Players ON;
INSERT INTO Players (Id, Name, Health, Experience)
VALUES
    (1, 'Sir Lancelot', 100, 0);
SET IDENTITY_INSERT Players OFF;

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
INSERT INTO Items (Id, Name, Value, Description, LinkedPlayerId, ItemType, AttackPower, DefensePower, Durability)
VALUES
    (1, 'Sword', 7.2, 'A sharp sword', 1, 'Weapon', 10, 0, 5),
    (2, 'Shield', 4.8, 'A sturdy shield', 1, 'Armor', 0, 5, 5),
    (3, 'Bracer', 2.5, 'A beaten-up bracer', 1, 'Armor', 0, 2, 2),
    (4, 'Dagger', 3.5, 'A small dagger', 1, 'Weapon', 5, 0, 3);
SET IDENTITY_INSERT Items OFF;


INSERT INTO PlayerAbilities (PlayersId, AbilitiesId)
VALUES
    (1, 1); 
