-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Dec 02, 2017 at 03:07 PM
-- Server version: 5.7.19
-- PHP Version: 5.6.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `snwl_planningsysteem`
--

-- --------------------------------------------------------

--
-- Table structure for table `chauffeurinfo`
--

DROP TABLE IF EXISTS `chauffeurinfo`;
CREATE TABLE IF NOT EXISTS `chauffeurinfo` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Firstname` varchar(160) NOT NULL,
  `Insertion` varchar(160) NOT NULL,
  `Lastname` varchar(160) NOT NULL,
  `Streetname` varchar(50) NOT NULL,
  `Housenumber` varchar(50) NOT NULL,
  `City` varchar(50) NOT NULL,
  `License` varchar(160) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=23423424 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `chauffeurinfo`
--

INSERT INTO `chauffeurinfo` (`ID`, `Firstname`, `Insertion`, `Lastname`, `Streetname`, `Housenumber`, `City`, `License`) VALUES
(1048, 'Erik', 'van den', 'Borg', '', '', '', ''),
(1832, 'Frans', '', 'Keizer', '', '', '', ''),
(1588, 'Jan', 'van', 'Dongeren', '', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `chauffeurs`
--

DROP TABLE IF EXISTS `chauffeurs`;
CREATE TABLE IF NOT EXISTS `chauffeurs` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Username` varchar(160) NOT NULL,
  `Password` varchar(160) NOT NULL,
  `Salt` varchar(160) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=23423424 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `chauffeurs`
--

INSERT INTO `chauffeurs` (`ID`, `Username`, `Password`, `Salt`) VALUES
(1048, 'e.borg', 'adb3e64b9eef255b43866b48132fc03b2181b6cc86a11bb77c4af38813d161bd', '2d16c4bb96b4'),
(1292, 'f.keizer', '26d3324f6c1258cb8a5b8e31491236162a7241bdc2497066b8a1aed42b66c321', 'd75c3d6bf052c4'),
(1163, 'j.dongeren', 'c2e293cd7e1c60c056ba9bd0c6753ff519ab5d088ccfc95880ffe7e387af75da', 'cdcbf405d5c3ce'),
(123, 'yoo', '75f823d8294402bcc6d1b8c6fe69f937b590b7674660a7223413240f6dafe6af', '281e47489de82a'),
(222, 'sdfdsdfs', '10e0f7c4c4ecd11617360365e982500f6a63d8a922db98b4ec89fe8961b9fc17', '9b92e122b148c8'),
(411, 'qweqwqw', '2dfb7ac45c7e74dc721d663200aae4a8a4f39e75c46f4784627f57cb2ed3d0f0', '3c8862642108d4'),
(1234, 'test', '28bd281eba5c103d82747feed0dad0494762b12d2cdb0b3a80ffb2a42e3761a6', '5d02a60f0747e8');

-- --------------------------------------------------------

--
-- Table structure for table `plannerinfo`
--

DROP TABLE IF EXISTS `plannerinfo`;
CREATE TABLE IF NOT EXISTS `plannerinfo` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Firstname` varchar(160) NOT NULL,
  `Insertion` varchar(160) NOT NULL,
  `Lastname` varchar(160) NOT NULL,
  `Streetname` varchar(160) NOT NULL,
  `Housenumber` varchar(160) NOT NULL,
  `City` varchar(160) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=34335 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `plannerinfo`
--

INSERT INTO `plannerinfo` (`ID`, `Firstname`, `Insertion`, `Lastname`, `Streetname`, `Housenumber`, `City`) VALUES
(3335, 'Piet', '', 'Meeresman', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `planners`
--

DROP TABLE IF EXISTS `planners`;
CREATE TABLE IF NOT EXISTS `planners` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Username` varchar(160) NOT NULL,
  `Password` varchar(160) NOT NULL,
  `Salt` varchar(150) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=34335 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `planners`
--

INSERT INTO `planners` (`ID`, `Username`, `Password`, `Salt`) VALUES
(1234, 'test', 'aacc201469a3318da2136e381d051d170d081d8794426d2f132cb82cd9853a87', '2a73c6f773364f'),
(3333, 'sdfsdf', 'af0bfab8162a73e6ddf73ffbd491ab3ce981fc94ab1109b14a7d9acdf3052446', '32ac975efa61b'),
(1525, 'p.meeresman', '0f1e59c99fa34875651a2e393cfe4fbffb0d5fb0f2f17e1ce32da32a198aec5a', '2c45c3ab1268f0'),
(3335, '4443sdf', 'a6a7583a10022706c022462d022d3c96be7a29dad955bb545c84be2da8aa8cc9', 'f55ffb0c10d060'),
(123, 'yoo', '521801722f858621acd5235bfa45a5371718dd975d18fe5a9c0832e8fe01adfd', '21f44d4169ddc6'),
(4421, 'asdasd', '5149c12548595ee00183511393ed6c54cc55b97ca363972fd2343142ec63b807', '8bcbb4e6f0e28e'),
(34334, 'dsfdfs', '9e959a10c9624947e384fa3fc1fc7f8bc710fc7ed0dc7075582c49f1ec55effc', '72c4ef0ce23160');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
