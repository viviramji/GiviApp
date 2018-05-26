-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 204.93.216.11    Database: ivanbano_grupo10
-- ------------------------------------------------------
-- Server version	5.5.28

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `services`
--

DROP TABLE IF EXISTS `services`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `services` (
  `serviceID` int(5) NOT NULL AUTO_INCREMENT,
  `description` varchar(255) NOT NULL,
  `date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `status_fk` int(1) NOT NULL,
  `typeService_fk` int(1) NOT NULL,
  `clientID_fk` int(5) NOT NULL,
  `adminID_fk` int(5) NOT NULL,
  `userID_fk` int(5) NOT NULL,
  PRIMARY KEY (`serviceID`),
  KEY `fk_client_fk` (`clientID_fk`),
  KEY `fk_adminID_fk` (`adminID_fk`),
  KEY `fk_typeService_fk` (`typeService_fk`),
  KEY `fk_userID_fk` (`userID_fk`),
  KEY `fk_status_fk` (`status_fk`),
  CONSTRAINT `fk_adminID_fk` FOREIGN KEY (`adminID_fk`) REFERENCES `admins` (`adminID_a`) ON DELETE CASCADE,
  CONSTRAINT `fk_client_fk` FOREIGN KEY (`clientID_fk`) REFERENCES `clients` (`clientID`) ON DELETE CASCADE,
  CONSTRAINT `fk_status_fk` FOREIGN KEY (`status_fk`) REFERENCES `typestatus` (`typeStatusID`) ON DELETE CASCADE,
  CONSTRAINT `fk_typeService_fk` FOREIGN KEY (`typeService_fk`) REFERENCES `typeservices` (`typeServiceID`) ON DELETE CASCADE,
  CONSTRAINT `fk_userID_fk` FOREIGN KEY (`userID_fk`) REFERENCES `users` (`userID_u`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-05-26 12:25:15
