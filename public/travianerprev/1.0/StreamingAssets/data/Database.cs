using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

namespace Assets.Scripts.Data
{
    public class Database : MonoBehaviour
    {
        private static string dbName = "URI=file:" + Application.dataPath + "/Data/Travianer.db";

        void Start()
        {
            CreateDB();
        }

        public static void CreateDB()
        {
            Debug.Log("Meow!");

            using (var connection = new SqliteConnection(dbName))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "CREATE TABLE IF NOT EXISTS BuildingTimes (BuildingName VARCHAR(30), Level INT, Hour INT, Min INT, Sec INT);";
                    command.ExecuteNonQuery();

                    command.CommandText = "CREATE TABLE IF NOT EXISTS BuildingProduction (BuildingName VARCHAR(30), Level INT, Wood INT, Clay INT, Iron INT, Wheat INT);";
                    command.ExecuteNonQuery();

                    command.CommandText = "CREATE TABLE IF NOT EXISTS StorageCapacity (BuildingName VARCHAR(30), Level INT, Capacity INT);";
                    command.ExecuteNonQuery();

                    command.CommandText = "CREATE TABLE IF NOT EXISTS MainBuildingInfo (BuildingName VARCHAR(30), Level INT, Speed REAL);";
                    command.ExecuteNonQuery();

                    command.CommandText = "CREATE TABLE IF NOT EXISTS PlayerNames (Name1 VARCHAR(30), Name2 VARCHAR(30), Gender VARCHAR(30), Fullname VARCHAR(30));";
                    command.ExecuteNonQuery();

                    command.CommandText = "CREATE TABLE IF NOT EXISTS AllianceNames (Name1 VARCHAR(30), Name2 VARCHAR(30), Fullname VARCHAR(30), Shortname VARCHAR(30));";
                    command.ExecuteNonQuery();

                    command.CommandText = "CREATE TABLE IF NOT EXISTS FounderBuildingsData (BuildingName VARCHAR(30), Level INT, Defence INT);";
                    command.ExecuteNonQuery();

                    command.CommandText = "CREATE TABLE IF NOT EXISTS CulturePoints (Village INT, Points INT);";
                    command.ExecuteNonQuery();

                    command.CommandText = "CREATE TABLE IF NOT EXISTS TrooperUpgrades (TrooperName VARCHAR(30), Level INT, Wood INT, Clay INT, Iron INT, Wheat INT, Hour INT, Min INT, Sec INT);";
                    command.ExecuteNonQuery();

                    command.CommandText = "CREATE TABLE IF NOT EXISTS TownHallInfo (Type VARCHAR(30), Level INT, Hour INT, Min INT, Sec INT);";
                    command.ExecuteNonQuery();

                    command.CommandText = "CREATE TABLE IF NOT EXISTS HeroInfo (Tribe VARCHAR(30), Level INT, Wood INT, Clay INT, Iron INT, Wheat INT);";
                    command.ExecuteNonQuery();

                    command.CommandText = "CREATE TABLE IF NOT EXISTS VillageNames (Adjective VARCHAR(30), VillageName VARCHAR(30));";
                    command.ExecuteNonQuery();

                    command.CommandText = "CREATE TABLE IF NOT EXISTS TrapperInfo (BuildingName VARCHAR(30), TrapCount INT);";
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public static void GetTimeRequirements(string buildingName, List<BuildingTime> timeRequirements)
        {
            using (var connection = new SqliteConnection(dbName))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM BuildingTimes;";

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if ((string)reader["BuildingName"] == buildingName)
                            {
                                BuildingTime time = new BuildingTime((int)reader["Hour"], (int)reader["Min"], (int)reader["Sec"]);

                                //Rounding to 5...
                                if (time.seconds % 5 <= 2)
                                {
                                    time.seconds -= (time.seconds % 5);
                                }
                                else
                                {
                                    time.seconds += 5 - (time.seconds % 5);
                                }

                                timeRequirements.Add(time);
                            }
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
        }

        public static void GetBuildingProductions(string buildingName, List<ResourceInt> productions)
        {
            using (var connection = new SqliteConnection(dbName))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM BuildingProduction;";

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if ((string)reader["BuildingName"] == buildingName)
                            {
                                ResourceInt production = new ResourceInt((int)reader["Wood"], (int)reader["Clay"], (int)reader["Iron"], (int)reader["Wheat"]);
                                productions.Add(production);
                            }
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
        }

        public static void GetStorageCapacities(string buildingName, List<ResourceInt> capacity)
        {
            using (var connection = new SqliteConnection(dbName))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM StorageCapacity;";

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if ((string)reader["BuildingName"] == "Warehouse" && buildingName == "Warehouse" || (string)reader["BuildingName"] == "Great Warehouse" && buildingName == "Great Warehouse")
                            {
                                int current_capacity = (int)reader["Capacity"];
                                ResourceInt storage = new ResourceInt(current_capacity, current_capacity, current_capacity, 0);
                                capacity.Add(storage);
                            }
                            else if ((string)reader["BuildingName"] == "Granary" && buildingName == "Granary" || (string)reader["BuildingName"] == "Great Granary" && buildingName == "Great Granary")
                            {
                                int current_capacity = (int)reader["Capacity"];
                                ResourceInt storage = new ResourceInt(0, 0, 0, current_capacity);
                                capacity.Add(storage);
                            }
                            else if ((string)reader["BuildingName"] == "Cranny" && buildingName == "Cranny")
                            {
                                int current_capacity = (int)reader["Capacity"];
                                ResourceInt storage = new ResourceInt(current_capacity, current_capacity, current_capacity, current_capacity);
                                capacity.Add(storage);
                            }
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
        }

        public static void GetMainBuildingSpeedBoost(string buildingName, List<float> buildingSpeeds)
        {
            using (var connection = new SqliteConnection(dbName))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM MainBuildingInfo;";

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if ((string)reader["BuildingName"] == buildingName)
                            {
                                buildingSpeeds.Add((float)reader["Speed"]);
                            }
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
        }

        public static void GetTownHallSpeedBoost(string type, List<BuildingTime> buildingSpeeds)
        {
            using (var connection = new SqliteConnection(dbName))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM TownHallInfo;";

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if ((string)reader["Type"] == type)
                            {
                                BuildingTime time = new BuildingTime((int)reader["Hour"], (int)reader["Min"], (int)reader["Sec"]);

                                //Rounding to 5...
                                if (time.seconds % 5 <= 2)
                                {
                                    time.seconds -= (time.seconds % 5);
                                }
                                else
                                {
                                    time.seconds += 5 - (time.seconds % 5);
                                }

                                buildingSpeeds.Add(time);
                            }
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
        }

        public static void GetRandomPlayerNames(List<string> nameList1, List<string> nameList2, List<string> fullnameList, List<string> genderList)
        {
            using (var connection = new SqliteConnection(dbName))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM PlayerNames;";

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            nameList1.Add((string)reader["Name1"]);
                            nameList2.Add((string)reader["Name2"]);
                            fullnameList.Add((string)reader["Fullname"]);
                            genderList.Add((string)reader["Gender"]);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
        }

        public static void GetRandomAllianceNames(List<string> nameList1, List<string> nameList2, List<string> fullnameList, List<string> shortnameList)
        {
            using (var connection = new SqliteConnection(dbName))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM AllianceNames;";

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            nameList1.Add((string)reader["Name1"]);
                            nameList2.Add((string)reader["Name2"]);
                            fullnameList.Add((string)reader["Fullname"]);
                            shortnameList.Add((string)reader["Shortname"]);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
        }

        public static void GetDefenceBonusesFromDatabase(string buildingName, List<int> defenceBonuses)
        {
            using (var connection = new SqliteConnection(dbName))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM FounderBuildingsData;";

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if ((string)reader["BuildingName"] == buildingName)
                            {
                                defenceBonuses.Add((int)reader["Defence"]);
                            }
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
        }

        public static void GetCulturePointLimitsFromDatabase(List<int> culturePointLimits)
        {
            using (var connection = new SqliteConnection(dbName))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM CulturePoints;";

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            culturePointLimits.Add((int)reader["Points"]);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
        }

        public static void GetUpgradeInfoFromDatabase(string trooperName, List<BuildingTime> upgradeTimes, List<ResourceRequirement> requirements)
        {
            using (var connection = new SqliteConnection(dbName))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM TrooperUpgrades;";

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if ((string)reader["TrooperName"] == trooperName)
                            {
                                ResourceRequirement req = new ResourceRequirement((int)reader["Wood"], (int)reader["Clay"], (int)reader["Iron"], (int)reader["Wheat"]);
                                requirements.Add(req);
                                BuildingTime time = new BuildingTime((int)reader["Hour"], (int)reader["Min"], (int)reader["Sec"]);
                                upgradeTimes.Add(time);
                            }
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
        }

        public static void GetHeroRessurrectionCost(List<ResourceInt> req, string tribe)
        {
            using (var connection = new SqliteConnection(dbName))
            {
                ResourceInt requirements = new ResourceInt(0, 0, 0, 0);
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM HeroInfo;";

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if ((string)reader["Tribe"] == tribe)
                            {
                                requirements = new ResourceInt((int)reader["Wood"], (int)reader["Clay"], (int)reader["Iron"], (int)reader["Wheat"]);
                                req.Add(requirements);
                            }
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
        }

        public static void GetVillageNamesFromDatabase(List<string> adjectives, List<string> villageNames)
        {
            using (var connection = new SqliteConnection(dbName))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM VillageNames;";

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["Adjective"] != DBNull.Value)
                            {
                                adjectives.Add((string)reader["Adjective"]);
                            }
                            villageNames.Add((string)reader["VillageName"]);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
        }

        public static void GetTrapperTrapCount(List<int> trapCountList)
        {
            using (var connection = new SqliteConnection(dbName))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM TrapperInfo;";

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            trapCountList.Add((int)reader["TrapCount"]);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
        }
    }
}
