-- phpMyAdmin SQL Dump
-- version 5.0.3
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 03-12-2020 a las 20:53:34
-- Versión del servidor: 10.4.14-MariaDB
-- Versión de PHP: 7.4.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `casimportaciones`
--
CREATE DATABASE IF NOT EXISTS `casimportaciones` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `casimportaciones`;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aspnetroleclaims`
--

CREATE TABLE IF NOT EXISTS `aspnetroleclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(127) NOT NULL,
  `ClaimType` text DEFAULT NULL,
  `ClaimValue` text DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aspnetroles`
--

CREATE TABLE IF NOT EXISTS `aspnetroles` (
  `Id` varchar(127) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aspnetuserclaims`
--

CREATE TABLE IF NOT EXISTS `aspnetuserclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(767) NOT NULL,
  `ClaimType` text DEFAULT NULL,
  `ClaimValue` text DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aspnetuserlogins`
--

CREATE TABLE IF NOT EXISTS `aspnetuserlogins` (
  `LoginProvider` varchar(127) NOT NULL,
  `ProviderKey` varchar(127) NOT NULL,
  `ProviderDisplayName` text DEFAULT NULL,
  `UserId` varchar(767) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aspnetuserroles`
--

CREATE TABLE IF NOT EXISTS `aspnetuserroles` (
  `UserId` varchar(127) NOT NULL,
  `RoleId` varchar(127) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aspnetusers`
--

CREATE TABLE IF NOT EXISTS `aspnetusers` (
  `Id` varchar(767) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` text DEFAULT NULL,
  `SecurityStamp` text DEFAULT NULL,
  `ConcurrencyStamp` text DEFAULT NULL,
  `PhoneNumber` text DEFAULT NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` timestamp NULL DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `aspnetusers`
--

INSERT INTO `aspnetusers` (`Id`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`) VALUES
('772fd9fa-8f50-4360-97ac-03b91353ff25', 'saruiz80@misena.edu.co', 'SARUIZ80@MISENA.EDU.CO', 'saruiz80@misena.edu.co', 'SARUIZ80@MISENA.EDU.CO', 1, 'AQAAAAEAACcQAAAAEDEZn7mpHRl6HCjKbKbGce1tgCDDafJCBPqc1TUt3VYGTwQ4BFUc3SIuAleJmqyhpA==', 'RTIZYVFUMV4EYS2ICSGELZ6DYS4LCZVV', '900be8b1-7f2f-4f41-8885-d33bd66e01bd', NULL, 0, 0, NULL, 1, 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aspnetusertokens`
--

CREATE TABLE IF NOT EXISTS `aspnetusertokens` (
  `UserId` varchar(127) NOT NULL,
  `LoginProvider` varchar(127) NOT NULL,
  `Name` varchar(127) NOT NULL,
  `Value` text DEFAULT NULL,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `categoria`
--

CREATE TABLE IF NOT EXISTS `categoria` (
  `IdCategoria` int(11) NOT NULL AUTO_INCREMENT,
  `Descripcion` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`IdCategoria`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `categoria`
--

INSERT INTO `categoria` (`IdCategoria`, `Descripcion`) VALUES
(1, 'Motor'),
(2, 'Suspensión'),
(3, 'Frenos');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inventario`
--

CREATE TABLE IF NOT EXISTS `inventario` (
  `IdInventario` int(11) NOT NULL AUTO_INCREMENT,
  `Referencia` varchar(255) DEFAULT NULL,
  `Cantidad` int(11) DEFAULT NULL,
  `Fecha` date NOT NULL,
  `IdProveedor` int(11) DEFAULT NULL,
  PRIMARY KEY (`IdInventario`),
  KEY `Referencia` (`Referencia`),
  KEY `IdProveedor` (`IdProveedor`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `inventario`
--

INSERT INTO `inventario` (`IdInventario`, `Referencia`, `Cantidad`, `Fecha`, `IdProveedor`) VALUES
(1, '17034-100-RIK-2', 5, '2020-12-09', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ordencompra`
--

CREATE TABLE IF NOT EXISTS `ordencompra` (
  `IdCompra` int(11) NOT NULL AUTO_INCREMENT,
  `Referencia` varchar(255) DEFAULT NULL,
  `Cantidad` int(11) NOT NULL,
  `FechaCompra` date NOT NULL,
  `IdProveedor` int(11) DEFAULT NULL,
  `IdUsuario` int(11) DEFAULT NULL,
  PRIMARY KEY (`IdCompra`),
  KEY `Referencia` (`Referencia`),
  KEY `IdProveedor` (`IdProveedor`),
  KEY `IdUsuario` (`IdUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ordencompra`
--

INSERT INTO `ordencompra` (`IdCompra`, `Referencia`, `Cantidad`, `FechaCompra`, `IdProveedor`, `IdUsuario`) VALUES
(1, '17034-100-RIK-2', 2, '2020-12-23', 1, 2);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ordenventa`
--

CREATE TABLE IF NOT EXISTS `ordenventa` (
  `IdVenta` int(11) NOT NULL AUTO_INCREMENT,
  `FechaVenta` date NOT NULL,
  `Cantidad` int(11) NOT NULL,
  `ValorTotal` double NOT NULL,
  `IdUsuario` int(11) DEFAULT NULL,
  PRIMARY KEY (`IdVenta`),
  KEY `IdUsuario` (`IdUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ordenventa`
--

INSERT INTO `ordenventa` (`IdVenta`, `FechaVenta`, `Cantidad`, `ValorTotal`, `IdUsuario`) VALUES
(1, '2020-12-24', 2, 100000, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `persona`
--

CREATE TABLE IF NOT EXISTS `persona` (
  `IdUsuario` int(11) NOT NULL AUTO_INCREMENT,
  `Identificacion` int(11) NOT NULL,
  `PrimerNombre` varchar(255) DEFAULT NULL,
  `SegundoNombre` varchar(255) DEFAULT NULL,
  `PrimerApellido` varchar(255) DEFAULT NULL,
  `SegundoApellido` varchar(255) DEFAULT NULL,
  `Direccion` varchar(255) NOT NULL,
  `IdTipo` int(11) DEFAULT NULL,
  `Id` varchar(767) DEFAULT NULL,
  PRIMARY KEY (`IdUsuario`),
  KEY `IdTipo` (`IdTipo`),
  KEY `Id` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `persona`
--

INSERT INTO `persona` (`IdUsuario`, `Identificacion`, `PrimerNombre`, `SegundoNombre`, `PrimerApellido`, `SegundoApellido`, `Direccion`, `IdTipo`, `Id`) VALUES
(1, 1006843684, 'Wilson', 'Jose', 'Velazques', NULL, 'Cra 159 #165', 1, NULL),
(2, 1000968152, 'Roger', 'Andres', 'Blanco', NULL, 'Cra 158 56-45', 1, NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `producto`
--

CREATE TABLE IF NOT EXISTS `producto` (
  `Referencia` varchar(255) NOT NULL,
  `Descripcion` varchar(255) DEFAULT NULL,
  `Precio` double NOT NULL,
  `Marca` varchar(255) DEFAULT NULL,
  `IdCategoria` int(11) DEFAULT NULL,
  `IdProveedor` int(11) DEFAULT NULL,
  PRIMARY KEY (`Referencia`),
  KEY `IdCategoria` (`IdCategoria`),
  KEY `IdProveedor` (`IdProveedor`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `producto`
--

INSERT INTO `producto` (`Referencia`, `Descripcion`, `Precio`, `Marca`, `IdCategoria`, `IdProveedor`) VALUES
('17034-100-RIK-2', 'ANILLOS MOTOR CHEV. LUV DMAX 3.5 6VE1 (ISUZU) 6CIL (SET\r\nDE 6 ANILLOS) GASOLINA 1.2/1.2/2.0 93.4mm / PLANO / (USAR\r\nC/PISTONES E9341)', 294000, 'RIK', 1, 1),
('241565-IOB', 'CILINDRO FRENO CHEV. SWIFT 1.3 TRASERO IZQUIERDO\r\n11/16\'\'', 18000, 'KAPITOL', 3, NULL),
('35616-075-2', 'ANILLOS MOTOR CHEV. ESTEEM/ SR413 1300CC', 50000, 'TP', 1, NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `proveedor`
--

CREATE TABLE IF NOT EXISTS `proveedor` (
  `IdProveedor` int(11) NOT NULL AUTO_INCREMENT,
  `NombreProveedor` varchar(255) DEFAULT NULL,
  `Direccion` varchar(255) DEFAULT NULL,
  `Telefono` double NOT NULL,
  `Ciudad` varchar(255) DEFAULT NULL,
  `IdTipo` int(11) DEFAULT NULL,
  `Identificacion` int(11) DEFAULT NULL,
  PRIMARY KEY (`IdProveedor`),
  KEY `IdTipo` (`IdTipo`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `proveedor`
--

INSERT INTO `proveedor` (`IdProveedor`, `NombreProveedor`, `Direccion`, `Telefono`, `Ciudad`, `IdTipo`, `Identificacion`) VALUES
(1, 'Japonesa de Repuestos', 'Calle 7 15-21', 2147483647, 'Bogotá', 2, 90065135);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipoidentificacion`
--

CREATE TABLE IF NOT EXISTS `tipoidentificacion` (
  `IdTipo` int(11) NOT NULL AUTO_INCREMENT,
  `Descripcion` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`IdTipo`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `tipoidentificacion`
--

INSERT INTO `tipoidentificacion` (`IdTipo`, `Descripcion`) VALUES
(1, 'Cedula de Ciudadanía'),
(2, 'NIT'),
(3, 'Cedula de Extranjería'),
(4, 'Pasaporte');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `__efmigrationshistory`
--

CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20201203054053_CreateIdentitySchema', '3.1.10');

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `inventario`
--
ALTER TABLE `inventario`
  ADD CONSTRAINT `inventario_ibfk_1` FOREIGN KEY (`Referencia`) REFERENCES `producto` (`Referencia`),
  ADD CONSTRAINT `inventario_ibfk_2` FOREIGN KEY (`IdProveedor`) REFERENCES `proveedor` (`IdProveedor`);

--
-- Filtros para la tabla `ordencompra`
--
ALTER TABLE `ordencompra`
  ADD CONSTRAINT `ordencompra_ibfk_1` FOREIGN KEY (`Referencia`) REFERENCES `producto` (`Referencia`),
  ADD CONSTRAINT `ordencompra_ibfk_2` FOREIGN KEY (`IdProveedor`) REFERENCES `proveedor` (`IdProveedor`),
  ADD CONSTRAINT `ordencompra_ibfk_3` FOREIGN KEY (`IdUsuario`) REFERENCES `persona` (`IdUsuario`);

--
-- Filtros para la tabla `ordenventa`
--
ALTER TABLE `ordenventa`
  ADD CONSTRAINT `ordenventa_ibfk_1` FOREIGN KEY (`IdUsuario`) REFERENCES `persona` (`IdUsuario`);

--
-- Filtros para la tabla `persona`
--
ALTER TABLE `persona`
  ADD CONSTRAINT `persona_ibfk_1` FOREIGN KEY (`IdTipo`) REFERENCES `tipoidentificacion` (`IdTipo`),
  ADD CONSTRAINT `persona_ibfk_2` FOREIGN KEY (`Id`) REFERENCES `aspnetusers` (`Id`);

--
-- Filtros para la tabla `producto`
--
ALTER TABLE `producto`
  ADD CONSTRAINT `producto_ibfk_1` FOREIGN KEY (`IdCategoria`) REFERENCES `categoria` (`IdCategoria`),
  ADD CONSTRAINT `producto_ibfk_2` FOREIGN KEY (`IdProveedor`) REFERENCES `proveedor` (`IdProveedor`);

--
-- Filtros para la tabla `proveedor`
--
ALTER TABLE `proveedor`
  ADD CONSTRAINT `proveedor_ibfk_1` FOREIGN KEY (`IdTipo`) REFERENCES `tipoidentificacion` (`IdTipo`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
