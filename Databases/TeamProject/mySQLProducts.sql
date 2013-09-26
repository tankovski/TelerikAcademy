SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE SCHEMA IF NOT EXISTS `supermarket` DEFAULT CHARACTER SET utf8 ;
USE `supermarket` ;

-- -----------------------------------------------------
-- Table `supermarket`.`measures`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `supermarket`.`measures` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT ,
  `Measure_Name` VARCHAR(200) NULL DEFAULT NULL ,
  PRIMARY KEY (`ID`) ,
  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `supermarket`.`vendors`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `supermarket`.`vendors` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT,
  `Vendor_Name` VARCHAR(200) NULL ,
  PRIMARY KEY (`ID`) ,
  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `supermarket`.`products`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `supermarket`.`products` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT ,
  `Product_Name` VARCHAR(200) NOT NULL ,
  `Base_Price` DECIMAL(10,2) NOT NULL ,
  `measures_ID` INT(11) NOT NULL ,
  `vendors_ID` INT(11) NOT NULL ,
  PRIMARY KEY (`ID`) ,
  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC) ,
  INDEX `fk_products_measures_idx` (`measures_ID` ASC) ,
  INDEX `fk_products_vendors1_idx` (`vendors_ID` ASC) ,
  CONSTRAINT `fk_products_measures`
    FOREIGN KEY (`measures_ID` )
    REFERENCES `supermarket`.`measures` (`ID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_products_vendors1`
    FOREIGN KEY (`vendors_ID` )
    REFERENCES `supermarket`.`vendors` (`ID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 1
DEFAULT CHARACTER SET = utf8;

USE `supermarket` ;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

-- -----------------------------------------------------
-- Data for table `supermarket`.`measures`
-- -----------------------------------------------------
START TRANSACTION;
USE `supermarket`;
INSERT INTO `supermarket`.`measures` ( `Measure_Name`) VALUES ('liters');
INSERT INTO `supermarket`.`measures` ( `Measure_Name`) VALUES ('pieces');
INSERT INTO `supermarket`.`measures` ( `Measure_Name`) VALUES ('grams');
INSERT INTO `supermarket`.`measures` ( `Measure_Name`) VALUES ('packs');
INSERT INTO `supermarket`.`measures` ( `Measure_Name`) VALUES ('kg');

COMMIT;

-- -----------------------------------------------------
-- Data for table `supermarket`.`vendors`
-- -----------------------------------------------------
START TRANSACTION;
USE `supermarket`;
INSERT INTO `supermarket`.`vendors` (`Vendor_Name`) VALUES ('Zagorka OOD');
INSERT INTO `supermarket`.`vendors` (`Vendor_Name`) VALUES ('Vin Prom Targovishte OOD');
INSERT INTO `supermarket`.`vendors` (`Vendor_Name`) VALUES ('Beck\'s LTD');
INSERT INTO `supermarket`.`vendors` (`Vendor_Name`) VALUES ('Nestle Corp.');
INSERT INTO `supermarket`.`vendors` (`Vendor_Name`) VALUES ('Svoge LTD');
INSERT INTO `supermarket`.`vendors` (`Vendor_Name`) VALUES ('Kamenitza OOD');
INSERT INTO `supermarket`.`vendors` (`Vendor_Name`) VALUES ('Bourgas Salams LTD');
INSERT INTO `supermarket`.`vendors` (`Vendor_Name`) VALUES ('Ariana Corp.');
INSERT INTO `supermarket`.`vendors` (`Vendor_Name`) VALUES ('LIDL Corp.');
INSERT INTO `supermarket`.`vendors` (`Vendor_Name`) VALUES ( 'Haribo Sweets LTD');
INSERT INTO `supermarket`.`vendors` (`Vendor_Name`) VALUES ( 'Amstel OOD');
INSERT INTO `supermarket`.`vendors` (`Vendor_Name`) VALUES ( 'Haineken LTD');
INSERT INTO `supermarket`.`vendors` (`Vendor_Name`) VALUES ( 'LEKI Corp.');
INSERT INTO `supermarket`.`vendors` (`Vendor_Name`) VALUES ( 'Sami M OOD');
INSERT INTO `supermarket`.`vendors` (`Vendor_Name`) VALUES ( 'Jim Beam LTD');
INSERT INTO `supermarket`.`vendors` (`Vendor_Name`) VALUES ( 'Sobieski OOD');
INSERT INTO `supermarket`.`vendors` (`Vendor_Name`) VALUES ( '7Days Corp.');
INSERT INTO `supermarket`.`vendors` (`Vendor_Name`) VALUES ( 'Milka OOD');
INSERT INTO `supermarket`.`vendors` (`Vendor_Name`) VALUES ( 'Deroni Corp');
INSERT INTO `supermarket`.`vendors` (`Vendor_Name`) VALUES ( 'Olineza Corp.');

COMMIT;

-- -----------------------------------------------------
-- Data for table `supermarket`.`products`
-- -----------------------------------------------------
START TRANSACTION;
USE `supermarket`;
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ('Beer \"Zagorka\"', 0.95, 1, 1);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ('Vodka \"Targovishte\"', 7.85, 1, 2);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ('30Beer \"Beck\'s\"', 0.69, 1, 3);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ('Chocolate \"Nestle\"', 2.8, 3, 4);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ('Chocolate \"Svoge\"', 2.2, 3, 5);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ('Beer \"Kamenitza\"', 1, 1, 6);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ('Shpek \"Bourgas\"', 6.36, 3, 7);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ('Beer \"Ariana\"', 0.95, 1, 8);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ('Popcorn \"Lidl\"', 0.55, 2, 9);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Gummy Bears \"Haribo\"', 3.25, 3, 10);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Beer \"Amstel\"', 0.95, 1, 11);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Beer \"Haineken\"', 3.2, 1, 12);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Shpek \"Leki\"', 6.99, 3, 13);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Teleshki Salam \"Leki\"', 2.8, 3, 13);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Kamchiq Salam \"Leki\"', 3.2, 3, 13);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Shpek \"Sami M\"', 5.69, 3, 14);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Donut \"Lidl\"', 0.65, 2, 9);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Whiskey \"JB\"', 17.89, 1, 15);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Vodka \"Sobieski\"', 13.25, 1, 16);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Lutenica \"Olineza\"', 3.99, 1, 20);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Majoneza \"Olineza\"', 4.25, 1, 20);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Ketchup \"Olineza\"', 1.65, 1, 20);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Gorchitza \"Olineza\"', 1, 1, 20);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Ketchup Detski \"Olineza\"', 3.65, 1, 20);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Kroasan \"7Days\"', 0.95, 3, 17);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Suha Pasta \"7Days\"', 0.4, 3, 17);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Vafla \"7Days\"', 0.3, 3, 17);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Neskafe \"Nestle\"', 0.29, 2, 4);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Nestea \"Nestle\"', 3.2, 1, 4);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Figaro \"Nestle\"', 3.88, 3, 4);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Almond \"Nestle\"', 3.99, 3, 4);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Vafla \"Nestle\"', 0.5, 3, 4);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Chocolate \"Milka\"', 2.2, 3, 18);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Vafla \"Milka\"', 0.65, 3, 18);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Bonboni \"Milka\"', 3.99, 3, 18);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Biskviti \"Milka\"', 2.33, 3, 18);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Lutenitza \"Deroni\"', 3.99, 1, 19);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Ketchup \"Deroni\"', 1.99, 1, 19);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Majoneza \"Deroni\"', 3.98, 1, 19);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Gorchitza \"Deroni\"', 1.65, 1, 19);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Ketchup Detski \"Deroni\"', 3.22, 1, 19);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Nadenitza \"Leki\"', 4.55, 3, 13);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Lionska Nadenitza \"Leki\"', 3.66, 3, 13);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Nadenitza \"Sami M\"', 4.22, 3, 14);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Teleshki Salam \"Sami M\"', 3.2, 3, 14);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Kamchiq Salam \"Sami M\"', 3.5, 3, 14);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Kajma \"Sami M\"', 3.99, 3, 14);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Kajma \"Leki\"', 3.66, 3, 13);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Sos Tartar \"Deroni\"', 3.2, 1, 19);
INSERT INTO `supermarket`.`products` ( `Product_Name`, `Base_Price`, `measures_ID`, `vendors_ID`) VALUES ( 'Sos Barbecue \"Olineza\"', 3.5, 1, 20);

COMMIT;
