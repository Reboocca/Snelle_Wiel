-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Nov 12, 2017 at 12:38 PM
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
-- Database: `kassasysteem_iis`
--

-- --------------------------------------------------------

--
-- Table structure for table `kassamedewerkers`
--

DROP TABLE IF EXISTS `kassamedewerkers`;
CREATE TABLE IF NOT EXISTS `kassamedewerkers` (
  `ID` int(11) NOT NULL,
  `Voornaam` varchar(50) NOT NULL,
  `Tussenvoegsel` varchar(50) NOT NULL,
  `Achternaam` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `kassamedewerkers`
--

INSERT INTO `kassamedewerkers` (`ID`, `Voornaam`, `Tussenvoegsel`, `Achternaam`) VALUES
(1, 'Aaron', 'van', 'Meggelen'),
(2, 'Desley', '', 'Bakker'),
(3, 'Elisa', '', 'Vosters');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Username` varchar(60) NOT NULL,
  `Password` varchar(60) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`ID`, `Username`, `Password`) VALUES
(1, 'kassa1', '$2a$10$S/t.hJl.vnZy40ar8t4Cf.90150uKFwylqDB2O3Z6kgYVg8hYY102'),
(2, 'kassa2', '$2a$10$P44r6jR6tbLsQzKBPnYSy./qPhR6PZeAlm7LijPn9OVs6ZjwUZeb6'),
(3, 'kassa3', '$2a$10$eyJmBR/abfFfM6/vMhz89OsWGF32rR9DpGTFN1uquHNtd0T68bWTS');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
