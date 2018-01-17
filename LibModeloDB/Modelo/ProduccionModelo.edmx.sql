-- -----------------------------------------------------------
-- Entity Designer DDL Script for MySQL Server 4.1 and higher
-- -----------------------------------------------------------
-- Date Created: 01/17/2018 13:53:11

-- Generated from EDMX file: F:\RecentProjects\ExcelProjects\LibModeloDB\Modelo\ProduccionModelo.edmx
-- Target version: 3.0.0.0

-- --------------------------------------------------


DROP DATABASE IF EXISTS `test`;
CREATE DATABASE `test`;
USE `test`;


-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- NOTE: if the constraint does not exist, an ignorable error will be reported.
-- --------------------------------------------------



-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------
SET foreign_key_checks = 0;

SET foreign_key_checks = 1;

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------


CREATE TABLE `Clientes`(
	`IdCliente` bigint NOT NULL AUTO_INCREMENT UNIQUE, 
	`NombreCliente` varchar (250) NOT NULL);

ALTER TABLE `Clientes` ADD PRIMARY KEY (IdCliente);





CREATE TABLE `FamiliasMateriales`(
	`FamiliaMaterialesId` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`NombreFamiliaMateriales` longtext NOT NULL);

ALTER TABLE `FamiliasMateriales` ADD PRIMARY KEY (FamiliaMaterialesId);





CREATE TABLE `Materiales`(
	`MaterialId` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`Apariencia` varchar (250) NOT NULL, 
	`Densidad` decimal( 6, 3 )  NOT NULL, 
	`FamiliaMaterialesId` int NOT NULL);

ALTER TABLE `Materiales` ADD PRIMARY KEY (MaterialId);


-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------


-- Creating foreign key on `FamiliaMaterialesId` in table 'Materiales'

ALTER TABLE `Materiales`
ADD CONSTRAINT `FK_FamiliaMaterialesMaterial`
    FOREIGN KEY (`FamiliaMaterialesId`)
    REFERENCES `FamiliasMateriales`
        (`FamiliaMaterialesId`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;


-- Creating non-clustered index for FOREIGN KEY 'FK_FamiliaMaterialesMaterial'

CREATE INDEX `IX_FK_FamiliaMaterialesMaterial`
    ON `Materiales`
    (`FamiliaMaterialesId`);



-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
