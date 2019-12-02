-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.1.32-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win32
-- HeidiSQL Version:             9.5.0.5196
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping database structure for workflow_app
CREATE DATABASE IF NOT EXISTS `workflow_app` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `workflow_app`;

-- Dumping structure for table workflow_app.admin
CREATE TABLE IF NOT EXISTS `admin` (
  `UserID` varchar(16) NOT NULL,
  `Type` varchar(16) NOT NULL,
  `EmailAddress` varchar(200) NOT NULL,
  `Password` varchar(255) NOT NULL,
  `Firstname` varchar(255) NOT NULL,
  `Lastname` varchar(255) NOT NULL,
  PRIMARY KEY (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table workflow_app.admin: ~2 rows (approximately)
/*!40000 ALTER TABLE `admin` DISABLE KEYS */;
INSERT INTO `admin` (`UserID`, `Type`, `EmailAddress`, `Password`, `Firstname`, `Lastname`) VALUES
	('lect1234', 'lecturer', 'arnold@school.com', 'aronold1', 'Arnold', 'Peterson');
/*!40000 ALTER TABLE `admin` ENABLE KEYS */;

-- Dumping structure for table workflow_app.course
CREATE TABLE IF NOT EXISTS `course` (
  `Course Code` varchar(16) NOT NULL,
  `Course Title` varchar(255) NOT NULL,
  PRIMARY KEY (`Course Code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table workflow_app.course: ~0 rows (approximately)
/*!40000 ALTER TABLE `course` DISABLE KEYS */;
/*!40000 ALTER TABLE `course` ENABLE KEYS */;

-- Dumping structure for table workflow_app.course_assignments
CREATE TABLE IF NOT EXISTS `course_assignments` (
  `UserID` varchar(16) NOT NULL,
  `Course Code` varchar(16) NOT NULL,
  `Date Assigned` date NOT NULL,
  UNIQUE KEY `CourseAssignmentIndex` (`UserID`,`Course Code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table workflow_app.course_assignments: ~0 rows (approximately)
/*!40000 ALTER TABLE `course_assignments` DISABLE KEYS */;
/*!40000 ALTER TABLE `course_assignments` ENABLE KEYS */;

-- Dumping structure for table workflow_app.course_registration
CREATE TABLE IF NOT EXISTS `course_registration` (
  `Course Code` varchar(16) NOT NULL,
  `UserID` varchar(16) NOT NULL,
  `Date Registered` date NOT NULL,
  UNIQUE KEY `CourseRegistrationID` (`Course Code`,`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table workflow_app.course_registration: ~0 rows (approximately)
/*!40000 ALTER TABLE `course_registration` DISABLE KEYS */;
/*!40000 ALTER TABLE `course_registration` ENABLE KEYS */;

-- Dumping structure for table workflow_app.mail
CREATE TABLE IF NOT EXISTS `mail` (
  `MailID` varchar(255) NOT NULL,
  `From` varchar(255) NOT NULL,
  `To` varchar(255) NOT NULL,
  `Subject` varchar(255) NOT NULL,
  `Message` varchar(255) NOT NULL,
  `Read` bit(1) NOT NULL,
  PRIMARY KEY (`MailID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table workflow_app.mail: ~0 rows (approximately)
/*!40000 ALTER TABLE `mail` DISABLE KEYS */;
/*!40000 ALTER TABLE `mail` ENABLE KEYS */;

-- Dumping structure for table workflow_app.post
CREATE TABLE IF NOT EXISTS `post` (
  `ID` varchar(255) NOT NULL,
  `Message` varchar(255) NOT NULL,
  `Broadcast` varchar(255) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table workflow_app.post: ~0 rows (approximately)
/*!40000 ALTER TABLE `post` DISABLE KEYS */;
/*!40000 ALTER TABLE `post` ENABLE KEYS */;

-- Dumping structure for table workflow_app.student
CREATE TABLE IF NOT EXISTS `student` (
  `UserID` varchar(16) NOT NULL,
  `EmailAddress` varchar(255) NOT NULL,
  `Password` varchar(255) NOT NULL,
  `Level` int(16) NOT NULL,
  `Firstname` varchar(255) NOT NULL,
  `Lastname` varchar(255) NOT NULL,
  PRIMARY KEY (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table workflow_app.student: ~2 rows (approximately)
/*!40000 ALTER TABLE `student` DISABLE KEYS */;
INSERT INTO `student` (`UserID`, `EmailAddress`, `Password`, `Level`, `Firstname`, `Lastname`) VALUES
	('140805059', 'analogbeichibueze@gmail.com', 'chibueze', 5, 'Chibueze', 'Analogbei');
/*!40000 ALTER TABLE `student` ENABLE KEYS */;

-- Dumping structure for table workflow_app.web_admin
CREATE TABLE IF NOT EXISTS `web_admin` (
  `UserID` varchar(16) NOT NULL,
  `EmailAddress` varchar(255) DEFAULT NULL,
  `Password` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table workflow_app.web_admin: ~0 rows (approximately)
/*!40000 ALTER TABLE `web_admin` DISABLE KEYS */;
/*!40000 ALTER TABLE `web_admin` ENABLE KEYS */;

-- Dumping structure for table workflow_app.workflow
CREATE TABLE IF NOT EXISTS `workflow` (
  `WorkflowID` varchar(16) NOT NULL,
  `WorkflowTypeID` varchar(16) NOT NULL,
  `Value` longtext NOT NULL,
  PRIMARY KEY (`WorkflowID`),
  UNIQUE KEY `WorkflowTypeID` (`WorkflowTypeID`),
  CONSTRAINT `FK_workflow_workflow_type` FOREIGN KEY (`WorkflowTypeID`) REFERENCES `workflow_type` (`WorkflowTypeID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table workflow_app.workflow: ~0 rows (approximately)
/*!40000 ALTER TABLE `workflow` DISABLE KEYS */;
/*!40000 ALTER TABLE `workflow` ENABLE KEYS */;

-- Dumping structure for table workflow_app.workflow_type
CREATE TABLE IF NOT EXISTS `workflow_type` (
  `WorkflowTypeID` varchar(16) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Requirements` longtext NOT NULL,
  PRIMARY KEY (`WorkflowTypeID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table workflow_app.workflow_type: ~1 rows (approximately)
/*!40000 ALTER TABLE `workflow_type` DISABLE KEYS */;
INSERT INTO `workflow_type` (`WorkflowTypeID`, `Name`, `Requirements`) VALUES
	('1123', 'Sample', '[{"type":"Picture","description":"Passport"},{"type":"File","description":"Course Form"}]');
/*!40000 ALTER TABLE `workflow_type` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
