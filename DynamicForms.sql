-- MySQL dump 10.13  Distrib 8.0.33, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: DynamicForms
-- ------------------------------------------------------
-- Server version	9.1.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `FieldTypes`
--

DROP TABLE IF EXISTS `FieldTypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `FieldTypes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `FieldTypes`
--

/*!40000 ALTER TABLE `FieldTypes` DISABLE KEYS */;
INSERT INTO `FieldTypes` VALUES (1,'number'),(2,'text'),(3,'date');
/*!40000 ALTER TABLE `FieldTypes` ENABLE KEYS */;

--
-- Table structure for table `Fields`
--

DROP TABLE IF EXISTS `Fields`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Fields` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FormId` int NOT NULL,
  `Name` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `FieldTypeId` int NOT NULL,
  `isRequired` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Fields_FieldTypeId` (`FieldTypeId`),
  KEY `IX_Fields_FormId` (`FormId`),
  CONSTRAINT `FK_Fields_FieldTypes_FieldTypeId` FOREIGN KEY (`FieldTypeId`) REFERENCES `FieldTypes` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Fields_Forms_FormId` FOREIGN KEY (`FormId`) REFERENCES `Forms` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Fields`
--

/*!40000 ALTER TABLE `Fields` DISABLE KEYS */;
INSERT INTO `Fields` VALUES (11,4,'Nombre',2,1),(13,7,'Nombre',2,1),(14,4,'Fecha de Nacimiento',3,1),(15,4,'Estatura',1,1),(16,7,'Especie',2,1),(17,7,'Raza',2,1),(18,7,'Color',2,1);
/*!40000 ALTER TABLE `Fields` ENABLE KEYS */;

--
-- Table structure for table `FormValues`
--

DROP TABLE IF EXISTS `FormValues`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `FormValues` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FormId` int NOT NULL,
  `Value` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_FormValues_FormId` (`FormId`),
  CONSTRAINT `FK_FormValues_Forms_FormId` FOREIGN KEY (`FormId`) REFERENCES `Forms` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `FormValues`
--

/*!40000 ALTER TABLE `FormValues` DISABLE KEYS */;
/*!40000 ALTER TABLE `FormValues` ENABLE KEYS */;

--
-- Table structure for table `Forms`
--

DROP TABLE IF EXISTS `Forms`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Forms` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Forms`
--

/*!40000 ALTER TABLE `Forms` DISABLE KEYS */;
INSERT INTO `Forms` VALUES (4,'Personas','Formulario para personas'),(7,'Mascotas','Formulario para mascotas');
/*!40000 ALTER TABLE `Forms` ENABLE KEYS */;

--
-- Table structure for table `__EFMigrationsHistory`
--

DROP TABLE IF EXISTS `__EFMigrationsHistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__EFMigrationsHistory`
--

/*!40000 ALTER TABLE `__EFMigrationsHistory` DISABLE KEYS */;
INSERT INTO `__EFMigrationsHistory` VALUES ('20241018135650_Initial','8.0.10');
/*!40000 ALTER TABLE `__EFMigrationsHistory` ENABLE KEYS */;

--
-- Dumping routines for database 'DynamicForms'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-10-19 12:48:34
