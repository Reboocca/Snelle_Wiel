-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Gegenereerd op: 24 nov 2017 om 11:02
-- Serverversie: 5.7.19
-- PHP-versie: 7.1.9

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
-- Tabelstructuur voor tabel `chauffeurinfo`
--

DROP TABLE IF EXISTS `chauffeurinfo`;
CREATE TABLE IF NOT EXISTS `chauffeurinfo` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Voornaam` varchar(160) NOT NULL,
  `Tussenvoegsel` varchar(160) NOT NULL,
  `Achternaam` varchar(160) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=1833 DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `chauffeurinfo`
--

INSERT INTO `chauffeurinfo` (`ID`, `Voornaam`, `Tussenvoegsel`, `Achternaam`) VALUES
(1386, 'Erik', 'van den', 'Borg'),
(1832, 'Frans', '', 'Keizer'),
(1588, 'Jan', 'van', 'Dongeren');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `chauffeurs`
--

DROP TABLE IF EXISTS `chauffeurs`;
CREATE TABLE IF NOT EXISTS `chauffeurs` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Username` varchar(160) NOT NULL,
  `Password` varchar(160) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=1387 DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `chauffeurs`
--

INSERT INTO `chauffeurs` (`ID`, `Username`, `Password`) VALUES
(1386, 'e.borg', '$2a$10$V4vsz4sBAcQWLoQCEgG3PeKWaKRU34FtCThXrfeL3ALutQgqUNkiy');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `userinfo`
--

DROP TABLE IF EXISTS `userinfo`;
CREATE TABLE IF NOT EXISTS `userinfo` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Voornaam` varchar(160) NOT NULL,
  `Tussenvoegsel` varchar(160) NOT NULL,
  `Achternaam` varchar(160) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `users`
--

DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Username` varchar(160) NOT NULL,
  `Password` varchar(160) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=1524 DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `users`
--

INSERT INTO `users` (`ID`, `Username`, `Password`) VALUES
(1523, 'p.meeresman', '$2a$10$CDiSp0e9BokshzEvqGCgqeUqPfzY36OcH9vDoEf..ud76oW/ayJdq');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
