
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 01/14/2021 22:54:59
-- Generated from EDMX file: D:\VITA\Final Project\FInalProject\FInalProject\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [FinalProjects];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CarCategoriesCar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [FK_CarCategoriesCar];
GO
IF OBJECT_ID(N'[dbo].[FK_hub_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [FK_hub_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_StateCity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cities] DROP CONSTRAINT [FK_StateCity];
GO
IF OBJECT_ID(N'[dbo].[FK_CityHub]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Hubs] DROP CONSTRAINT [FK_CityHub];
GO
IF OBJECT_ID(N'[dbo].[FK_HubEmployee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_HubEmployee];
GO
IF OBJECT_ID(N'[dbo].[FK_HubBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK_HubBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerCity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cities] DROP CONSTRAINT [FK_CustomerCity];
GO
IF OBJECT_ID(N'[dbo].[FK_CityBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK_CityBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_StateBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK_StateBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_CarCategoriesBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK_CarCategoriesBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_CarBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [FK_CarBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK_CustomerBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_CarCategoriesBilling]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Billings] DROP CONSTRAINT [FK_CarCategoriesBilling];
GO
IF OBJECT_ID(N'[dbo].[FK_CarBilling]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Billings] DROP CONSTRAINT [FK_CarBilling];
GO
IF OBJECT_ID(N'[dbo].[FK_BookingBilling]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Billings] DROP CONSTRAINT [FK_BookingBilling];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerBilling]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Billings] DROP CONSTRAINT [FK_CustomerBilling];
GO
IF OBJECT_ID(N'[dbo].[FK_HubBooking1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK_HubBooking1];
GO
IF OBJECT_ID(N'[dbo].[FK_HubBilling]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Billings] DROP CONSTRAINT [FK_HubBilling];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[CarCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarCategories];
GO
IF OBJECT_ID(N'[dbo].[Cars]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cars];
GO
IF OBJECT_ID(N'[dbo].[Hubs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Hubs];
GO
IF OBJECT_ID(N'[dbo].[Cities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cities];
GO
IF OBJECT_ID(N'[dbo].[States]', 'U') IS NOT NULL
    DROP TABLE [dbo].[States];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[Bookings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bookings];
GO
IF OBJECT_ID(N'[dbo].[Billings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Billings];
GO
IF OBJECT_ID(N'[dbo].[Ammenities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ammenities];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [customerId] int IDENTITY(1,1) NOT NULL,
    [first_name] nvarchar(max)  NOT NULL,
    [last_name] nvarchar(max)  NOT NULL,
    [address] nvarchar(max)  NOT NULL,
    [emailId] nvarchar(max)  NOT NULL,
    [city] nvarchar(max)  NOT NULL,
    [cellNo] bigint  NOT NULL,
    [creditcardType] nvarchar(max)  NOT NULL,
    [creditcard_Number] bigint  NOT NULL,
    [drivingLiscen_Number] bigint  NOT NULL,
    [validThrough] nvarchar(max)  NOT NULL,
    [passport_Number] bigint  NOT NULL,
    [passport_valid] nvarchar(max)  NOT NULL,
    [password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CarCategories'
CREATE TABLE [dbo].[CarCategories] (
    [categoryId] int IDENTITY(1,1) NOT NULL,
    [categoryName] nvarchar(max)  NOT NULL,
    [imagePath] nvarchar(max)  NOT NULL,
    [dailyRates] decimal(18,0)  NOT NULL,
    [monthlyRates] decimal(18,0)  NOT NULL,
    [weaklyRates] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Cars'
CREATE TABLE [dbo].[Cars] (
    [carId] int IDENTITY(1,1) NOT NULL,
    [carName] nvarchar(max)  NOT NULL,
    [carNoPlate] nvarchar(max)  NOT NULL,
    [capacity] int  NOT NULL,
    [fuelType] nvarchar(max)  NOT NULL,
    [availability] int  NOT NULL,
    [CarCategories_categoryId] int  NOT NULL,
    [Hub_hubId] int  NOT NULL,
    [Booking_bookingId] int  NOT NULL
);
GO

-- Creating table 'Hubs'
CREATE TABLE [dbo].[Hubs] (
    [hubId] int IDENTITY(1,1) NOT NULL,
    [hubName] nvarchar(max)  NOT NULL,
    [contactNumber] bigint  NOT NULL,
    [address] nvarchar(max)  NOT NULL,
    [stateId] int  NOT NULL,
    [City_cityId] int  NOT NULL
);
GO

-- Creating table 'Cities'
CREATE TABLE [dbo].[Cities] (
    [cityId] int IDENTITY(1,1) NOT NULL,
    [cityName] nvarchar(max)  NOT NULL,
    [State_stateId] int  NOT NULL,
    [airportcode] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'States'
CREATE TABLE [dbo].[States] (
    [stateId] int IDENTITY(1,1) NOT NULL,
    [stateName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [empId] int IDENTITY(1,1) NOT NULL,
    [empName] nvarchar(max)  NOT NULL,
    [empMobNo] bigint  NOT NULL,
    [empMailId] nvarchar(max)  NOT NULL,
    [empAddress] nvarchar(max)  NOT NULL,
    [empSalary] int  NOT NULL,
    [empPassword] nvarchar(max)  NOT NULL,
    [Hub_hubId] int  NOT NULL
);
GO

-- Creating table 'Bookings'
CREATE TABLE [dbo].[Bookings] (
    [bookingId] int IDENTITY(1,1) NOT NULL,
    [bookingdateAndTime] nvarchar(max)  NOT NULL,
    [categoriId] int  NOT NULL,
    [customerFirstName] nvarchar(max)  NOT NULL,
    [customerLastName] nvarchar(max)  NOT NULL,
    [customerMobileNo] bigint  NOT NULL,
    [usermailId] nvarchar(max)  NOT NULL,
    [customerDLNo] nvarchar(max)  NOT NULL,
    [dropdateAndTime] nvarchar(max)  NOT NULL,
    [Hub_hubId] int  NOT NULL,
    [City_cityId] int  NOT NULL,
    [State_stateId] int  NOT NULL,
    [CarCategories_categoryId] int  NOT NULL,
    [carId] int  NOT NULL,
    [Customer_customerId] int  NOT NULL,
    [Hub_hubId1] int  NOT NULL
);
GO

-- Creating table 'Billings'
CREATE TABLE [dbo].[Billings] (
    [billingId] int IDENTITY(1,1) NOT NULL,
    [CarCategories_categoryId] int  NOT NULL,
    [Car_carId] int  NOT NULL,
    [Booking_bookingId] int  NOT NULL,
    [Customer_customerId] int  NOT NULL,
    [billingName] nvarchar(max)  NOT NULL,
    [fuelStatus] nvarchar(max)  NOT NULL,
    [startDate] nvarchar(max)  NOT NULL,
    [endDate] nvarchar(max)  NOT NULL,
    [userMailid] nvarchar(max)  NOT NULL,
    [customerMobNo] nvarchar(max)  NOT NULL,
    [Property1] nvarchar(max)  NOT NULL,
    [Hub_hubId] int  NOT NULL,
    [firstName] nvarchar(max)  NOT NULL,
    [lastName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Ammenities'
CREATE TABLE [dbo].[Ammenities] (
    [ammenitiesId] int IDENTITY(1,1) NOT NULL,
    [ammenitiesName] nvarchar(max)  NOT NULL,
    [ammenitiesRate] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [customerId] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([customerId] ASC);
GO

-- Creating primary key on [categoryId] in table 'CarCategories'
ALTER TABLE [dbo].[CarCategories]
ADD CONSTRAINT [PK_CarCategories]
    PRIMARY KEY CLUSTERED ([categoryId] ASC);
GO

-- Creating primary key on [carId] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [PK_Cars]
    PRIMARY KEY CLUSTERED ([carId] ASC);
GO

-- Creating primary key on [hubId] in table 'Hubs'
ALTER TABLE [dbo].[Hubs]
ADD CONSTRAINT [PK_Hubs]
    PRIMARY KEY CLUSTERED ([hubId] ASC);
GO

-- Creating primary key on [cityId] in table 'Cities'
ALTER TABLE [dbo].[Cities]
ADD CONSTRAINT [PK_Cities]
    PRIMARY KEY CLUSTERED ([cityId] ASC);
GO

-- Creating primary key on [stateId] in table 'States'
ALTER TABLE [dbo].[States]
ADD CONSTRAINT [PK_States]
    PRIMARY KEY CLUSTERED ([stateId] ASC);
GO

-- Creating primary key on [empId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([empId] ASC);
GO

-- Creating primary key on [bookingId] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [PK_Bookings]
    PRIMARY KEY CLUSTERED ([bookingId] ASC);
GO

-- Creating primary key on [billingId] in table 'Billings'
ALTER TABLE [dbo].[Billings]
ADD CONSTRAINT [PK_Billings]
    PRIMARY KEY CLUSTERED ([billingId] ASC);
GO

-- Creating primary key on [ammenitiesId] in table 'Ammenities'
ALTER TABLE [dbo].[Ammenities]
ADD CONSTRAINT [PK_Ammenities]
    PRIMARY KEY CLUSTERED ([ammenitiesId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CarCategories_categoryId] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [FK_CarCategoriesCar]
    FOREIGN KEY ([CarCategories_categoryId])
    REFERENCES [dbo].[CarCategories]
        ([categoryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CarCategoriesCar'
CREATE INDEX [IX_FK_CarCategoriesCar]
ON [dbo].[Cars]
    ([CarCategories_categoryId]);
GO

-- Creating foreign key on [Hub_hubId] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [FK_hub_Id]
    FOREIGN KEY ([Hub_hubId])
    REFERENCES [dbo].[Hubs]
        ([hubId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_hub_Id'
CREATE INDEX [IX_FK_hub_Id]
ON [dbo].[Cars]
    ([Hub_hubId]);
GO

-- Creating foreign key on [State_stateId] in table 'Cities'
ALTER TABLE [dbo].[Cities]
ADD CONSTRAINT [FK_StateCity]
    FOREIGN KEY ([State_stateId])
    REFERENCES [dbo].[States]
        ([stateId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StateCity'
CREATE INDEX [IX_FK_StateCity]
ON [dbo].[Cities]
    ([State_stateId]);
GO

-- Creating foreign key on [City_cityId] in table 'Hubs'
ALTER TABLE [dbo].[Hubs]
ADD CONSTRAINT [FK_CityHub]
    FOREIGN KEY ([City_cityId])
    REFERENCES [dbo].[Cities]
        ([cityId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CityHub'
CREATE INDEX [IX_FK_CityHub]
ON [dbo].[Hubs]
    ([City_cityId]);
GO

-- Creating foreign key on [Hub_hubId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_HubEmployee]
    FOREIGN KEY ([Hub_hubId])
    REFERENCES [dbo].[Hubs]
        ([hubId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HubEmployee'
CREATE INDEX [IX_FK_HubEmployee]
ON [dbo].[Employees]
    ([Hub_hubId]);
GO

-- Creating foreign key on [Hub_hubId] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK_HubBooking]
    FOREIGN KEY ([Hub_hubId])
    REFERENCES [dbo].[Hubs]
        ([hubId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HubBooking'
CREATE INDEX [IX_FK_HubBooking]
ON [dbo].[Bookings]
    ([Hub_hubId]);
GO

-- Creating foreign key on [City_cityId] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK_CityBooking]
    FOREIGN KEY ([City_cityId])
    REFERENCES [dbo].[Cities]
        ([cityId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CityBooking'
CREATE INDEX [IX_FK_CityBooking]
ON [dbo].[Bookings]
    ([City_cityId]);
GO

-- Creating foreign key on [State_stateId] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK_StateBooking]
    FOREIGN KEY ([State_stateId])
    REFERENCES [dbo].[States]
        ([stateId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StateBooking'
CREATE INDEX [IX_FK_StateBooking]
ON [dbo].[Bookings]
    ([State_stateId]);
GO

-- Creating foreign key on [CarCategories_categoryId] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK_CarCategoriesBooking]
    FOREIGN KEY ([CarCategories_categoryId])
    REFERENCES [dbo].[CarCategories]
        ([categoryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CarCategoriesBooking'
CREATE INDEX [IX_FK_CarCategoriesBooking]
ON [dbo].[Bookings]
    ([CarCategories_categoryId]);
GO

-- Creating foreign key on [Booking_bookingId] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [FK_CarBooking]
    FOREIGN KEY ([Booking_bookingId])
    REFERENCES [dbo].[Bookings]
        ([bookingId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CarBooking'
CREATE INDEX [IX_FK_CarBooking]
ON [dbo].[Cars]
    ([Booking_bookingId]);
GO

-- Creating foreign key on [Customer_customerId] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK_CustomerBooking]
    FOREIGN KEY ([Customer_customerId])
    REFERENCES [dbo].[Customers]
        ([customerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerBooking'
CREATE INDEX [IX_FK_CustomerBooking]
ON [dbo].[Bookings]
    ([Customer_customerId]);
GO

-- Creating foreign key on [CarCategories_categoryId] in table 'Billings'
ALTER TABLE [dbo].[Billings]
ADD CONSTRAINT [FK_CarCategoriesBilling]
    FOREIGN KEY ([CarCategories_categoryId])
    REFERENCES [dbo].[CarCategories]
        ([categoryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CarCategoriesBilling'
CREATE INDEX [IX_FK_CarCategoriesBilling]
ON [dbo].[Billings]
    ([CarCategories_categoryId]);
GO

-- Creating foreign key on [Car_carId] in table 'Billings'
ALTER TABLE [dbo].[Billings]
ADD CONSTRAINT [FK_CarBilling]
    FOREIGN KEY ([Car_carId])
    REFERENCES [dbo].[Cars]
        ([carId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CarBilling'
CREATE INDEX [IX_FK_CarBilling]
ON [dbo].[Billings]
    ([Car_carId]);
GO

-- Creating foreign key on [Booking_bookingId] in table 'Billings'
ALTER TABLE [dbo].[Billings]
ADD CONSTRAINT [FK_BookingBilling]
    FOREIGN KEY ([Booking_bookingId])
    REFERENCES [dbo].[Bookings]
        ([bookingId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingBilling'
CREATE INDEX [IX_FK_BookingBilling]
ON [dbo].[Billings]
    ([Booking_bookingId]);
GO

-- Creating foreign key on [Customer_customerId] in table 'Billings'
ALTER TABLE [dbo].[Billings]
ADD CONSTRAINT [FK_CustomerBilling]
    FOREIGN KEY ([Customer_customerId])
    REFERENCES [dbo].[Customers]
        ([customerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerBilling'
CREATE INDEX [IX_FK_CustomerBilling]
ON [dbo].[Billings]
    ([Customer_customerId]);
GO

-- Creating foreign key on [Hub_hubId1] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK_HubBooking1]
    FOREIGN KEY ([Hub_hubId1])
    REFERENCES [dbo].[Hubs]
        ([hubId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HubBooking1'
CREATE INDEX [IX_FK_HubBooking1]
ON [dbo].[Bookings]
    ([Hub_hubId1]);
GO

-- Creating foreign key on [Hub_hubId] in table 'Billings'
ALTER TABLE [dbo].[Billings]
ADD CONSTRAINT [FK_HubBilling]
    FOREIGN KEY ([Hub_hubId])
    REFERENCES [dbo].[Hubs]
        ([hubId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HubBilling'
CREATE INDEX [IX_FK_HubBilling]
ON [dbo].[Billings]
    ([Hub_hubId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------