
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/30/2021 16:27:57
-- Generated from EDMX file: G:\FAKULTET - materijali\IV GODINA\VIII SEMESTAR\BAZE PODATAKA 2\BP2_Projekat\BP2_Project\Server\ProjectDb.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BP2_Projekat_Db];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Vlasnik_racunaraPosjeduje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PosjedujeSet] DROP CONSTRAINT [FK_Vlasnik_racunaraPosjeduje];
GO
IF OBJECT_ID(N'[dbo].[FK_KomponentaSastoji_se]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sastoji_seSet] DROP CONSTRAINT [FK_KomponentaSastoji_se];
GO
IF OBJECT_ID(N'[dbo].[FK_KomponentaSastoji_se1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sastoji_seSet] DROP CONSTRAINT [FK_KomponentaSastoji_se1];
GO
IF OBJECT_ID(N'[dbo].[FK_RacunarKomponenta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KomponentaSet] DROP CONSTRAINT [FK_RacunarKomponenta];
GO
IF OBJECT_ID(N'[dbo].[FK_RacunarPosjeduje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PosjedujeSet] DROP CONSTRAINT [FK_RacunarPosjeduje];
GO
IF OBJECT_ID(N'[dbo].[FK_Racunarski_servisRadi]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RadiSet] DROP CONSTRAINT [FK_Racunarski_servisRadi];
GO
IF OBJECT_ID(N'[dbo].[FK_Serviser_racunaraRadi]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RadiSet] DROP CONSTRAINT [FK_Serviser_racunaraRadi];
GO
IF OBJECT_ID(N'[dbo].[FK_Racunarski_servisDonosi]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DonosiSet] DROP CONSTRAINT [FK_Racunarski_servisDonosi];
GO
IF OBJECT_ID(N'[dbo].[FK_PosjedujeDonosi]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DonosiSet] DROP CONSTRAINT [FK_PosjedujeDonosi];
GO
IF OBJECT_ID(N'[dbo].[FK_RadiServisira]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServisiraSet] DROP CONSTRAINT [FK_RadiServisira];
GO
IF OBJECT_ID(N'[dbo].[FK_DonosiServisira]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServisiraSet] DROP CONSTRAINT [FK_DonosiServisira];
GO
IF OBJECT_ID(N'[dbo].[FK_ServisiraGarantni_list]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServisiraSet] DROP CONSTRAINT [FK_ServisiraGarantni_list];
GO
IF OBJECT_ID(N'[dbo].[FK_Racunarski_servis_inherits_Servis]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServisSet_Racunarski_servis] DROP CONSTRAINT [FK_Racunarski_servis_inherits_Servis];
GO
IF OBJECT_ID(N'[dbo].[FK_Servis_mob_tel_inherits_Servis]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServisSet_Servis_mob_tel] DROP CONSTRAINT [FK_Servis_mob_tel_inherits_Servis];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Vlasnik_racunaraSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vlasnik_racunaraSet];
GO
IF OBJECT_ID(N'[dbo].[RacunarSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RacunarSet];
GO
IF OBJECT_ID(N'[dbo].[PosjedujeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PosjedujeSet];
GO
IF OBJECT_ID(N'[dbo].[ServisSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServisSet];
GO
IF OBJECT_ID(N'[dbo].[KomponentaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KomponentaSet];
GO
IF OBJECT_ID(N'[dbo].[Sastoji_seSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sastoji_seSet];
GO
IF OBJECT_ID(N'[dbo].[DonosiSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DonosiSet];
GO
IF OBJECT_ID(N'[dbo].[Serviser_racunaraSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Serviser_racunaraSet];
GO
IF OBJECT_ID(N'[dbo].[RadiSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RadiSet];
GO
IF OBJECT_ID(N'[dbo].[ServisiraSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServisiraSet];
GO
IF OBJECT_ID(N'[dbo].[Garantni_listSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Garantni_listSet];
GO
IF OBJECT_ID(N'[dbo].[ServisSet_Racunarski_servis]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServisSet_Racunarski_servis];
GO
IF OBJECT_ID(N'[dbo].[ServisSet_Servis_mob_tel]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServisSet_Servis_mob_tel];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Vlasnik_racunaraSet'
CREATE TABLE [dbo].[Vlasnik_racunaraSet] (
    [JMBG_vl] bigint  NOT NULL,
    [Ime_vl] nvarchar(max)  NOT NULL,
    [Prezime_vl] nvarchar(max)  NOT NULL,
    [Dat_rodjenja_vl] datetime  NOT NULL,
    [Adresa_vl_Ulica] nvarchar(max)  NOT NULL,
    [Adresa_vl_Grad] nvarchar(max)  NOT NULL,
    [Adresa_vl_Broj] int  NOT NULL,
    [Adresa_vl_PostanskiBroj] int  NOT NULL
);
GO

-- Creating table 'RacunarSet'
CREATE TABLE [dbo].[RacunarSet] (
    [ID_racunara] int IDENTITY(1,1) NOT NULL,
    [Proizvodjac] nvarchar(max)  NOT NULL,
    [Brzina_procesora] float  NOT NULL,
    [Kapacitet_RAM] int  NOT NULL,
    [Kapacitet_memorije] int  NOT NULL,
    [Vrsta_racunara] int  NOT NULL
);
GO

-- Creating table 'PosjedujeSet'
CREATE TABLE [dbo].[PosjedujeSet] (
    [Vlasnik_racunaraJMBG_vl] bigint  NOT NULL,
    [RacunarID_racunara] int  NOT NULL
);
GO

-- Creating table 'ServisSet'
CREATE TABLE [dbo].[ServisSet] (
    [ID_servisa] int IDENTITY(1,1) NOT NULL,
    [Naziv_serv] nvarchar(max)  NOT NULL,
    [Tip_serv] int  NOT NULL,
    [Adresa_serv_Ulica] nvarchar(max)  NOT NULL,
    [Adresa_serv_Grad] nvarchar(max)  NOT NULL,
    [Adresa_serv_Broj] int  NOT NULL,
    [Adresa_serv_PostanskiBroj] int  NOT NULL,
    [Br_tel_serv_Pozivni_broj] int  NOT NULL,
    [Br_tel_serv_Okrug] int  NOT NULL,
    [Br_tel_serv_Broj] int  NOT NULL
);
GO

-- Creating table 'KomponentaSet'
CREATE TABLE [dbo].[KomponentaSet] (
    [Id_komp] int IDENTITY(1,1) NOT NULL,
    [Naz_komp] nvarchar(max)  NOT NULL,
    [Cijena_komp] float  NOT NULL,
    [RacunarID_racunara] int  NULL
);
GO

-- Creating table 'Sastoji_seSet'
CREATE TABLE [dbo].[Sastoji_seSet] (
    [KomponentaId_komp] int  NOT NULL,
    [KomponentaId_komp1] int  NOT NULL
);
GO

-- Creating table 'DonosiSet'
CREATE TABLE [dbo].[DonosiSet] (
    [Racunarski_servisID_servisa] int  NOT NULL,
    [PosjedujeVlasnik_racunaraJMBG_vl] bigint  NOT NULL,
    [PosjedujeRacunarID_racunara] int  NOT NULL
);
GO

-- Creating table 'Serviser_racunaraSet'
CREATE TABLE [dbo].[Serviser_racunaraSet] (
    [JMBG_s] bigint  NOT NULL,
    [Ime_s] nvarchar(max)  NOT NULL,
    [Prezime_s] nvarchar(max)  NOT NULL,
    [Dat_rodjenja_s] datetime  NOT NULL
);
GO

-- Creating table 'RadiSet'
CREATE TABLE [dbo].[RadiSet] (
    [Racunarski_servisID_servisa] int  NOT NULL,
    [Serviser_racunaraJMBG_s] bigint  NOT NULL
);
GO

-- Creating table 'ServisiraSet'
CREATE TABLE [dbo].[ServisiraSet] (
    [Cijena_serv] float  NOT NULL,
    [Dat_potp] datetime  NOT NULL,
    [RadiRacunarski_servisID_servisa] int  NOT NULL,
    [RadiServiser_racunaraJMBG_s] bigint  NOT NULL,
    [DonosiRacunarski_servisID_servisa] int  NOT NULL,
    [DonosiPosjedujeVlasnik_racunaraJMBG_vl] bigint  NOT NULL,
    [DonosiPosjedujeRacunarID_racunara] int  NOT NULL,
    [Garantni_listId_gar_list] int  NULL
);
GO

-- Creating table 'Garantni_listSet'
CREATE TABLE [dbo].[Garantni_listSet] (
    [Id_gar_list] int IDENTITY(1,1) NOT NULL,
    [Period_vazenja] datetime  NOT NULL
);
GO

-- Creating table 'ServisSet_Racunarski_servis'
CREATE TABLE [dbo].[ServisSet_Racunarski_servis] (
    [ID_servisa] int  NOT NULL
);
GO

-- Creating table 'ServisSet_Servis_mob_tel'
CREATE TABLE [dbo].[ServisSet_Servis_mob_tel] (
    [ID_servisa] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [JMBG_vl] in table 'Vlasnik_racunaraSet'
ALTER TABLE [dbo].[Vlasnik_racunaraSet]
ADD CONSTRAINT [PK_Vlasnik_racunaraSet]
    PRIMARY KEY CLUSTERED ([JMBG_vl] ASC);
GO

-- Creating primary key on [ID_racunara] in table 'RacunarSet'
ALTER TABLE [dbo].[RacunarSet]
ADD CONSTRAINT [PK_RacunarSet]
    PRIMARY KEY CLUSTERED ([ID_racunara] ASC);
GO

-- Creating primary key on [Vlasnik_racunaraJMBG_vl], [RacunarID_racunara] in table 'PosjedujeSet'
ALTER TABLE [dbo].[PosjedujeSet]
ADD CONSTRAINT [PK_PosjedujeSet]
    PRIMARY KEY CLUSTERED ([Vlasnik_racunaraJMBG_vl], [RacunarID_racunara] ASC);
GO

-- Creating primary key on [ID_servisa] in table 'ServisSet'
ALTER TABLE [dbo].[ServisSet]
ADD CONSTRAINT [PK_ServisSet]
    PRIMARY KEY CLUSTERED ([ID_servisa] ASC);
GO

-- Creating primary key on [Id_komp] in table 'KomponentaSet'
ALTER TABLE [dbo].[KomponentaSet]
ADD CONSTRAINT [PK_KomponentaSet]
    PRIMARY KEY CLUSTERED ([Id_komp] ASC);
GO

-- Creating primary key on [KomponentaId_komp], [KomponentaId_komp1] in table 'Sastoji_seSet'
ALTER TABLE [dbo].[Sastoji_seSet]
ADD CONSTRAINT [PK_Sastoji_seSet]
    PRIMARY KEY CLUSTERED ([KomponentaId_komp], [KomponentaId_komp1] ASC);
GO

-- Creating primary key on [Racunarski_servisID_servisa], [PosjedujeVlasnik_racunaraJMBG_vl], [PosjedujeRacunarID_racunara] in table 'DonosiSet'
ALTER TABLE [dbo].[DonosiSet]
ADD CONSTRAINT [PK_DonosiSet]
    PRIMARY KEY CLUSTERED ([Racunarski_servisID_servisa], [PosjedujeVlasnik_racunaraJMBG_vl], [PosjedujeRacunarID_racunara] ASC);
GO

-- Creating primary key on [JMBG_s] in table 'Serviser_racunaraSet'
ALTER TABLE [dbo].[Serviser_racunaraSet]
ADD CONSTRAINT [PK_Serviser_racunaraSet]
    PRIMARY KEY CLUSTERED ([JMBG_s] ASC);
GO

-- Creating primary key on [Racunarski_servisID_servisa], [Serviser_racunaraJMBG_s] in table 'RadiSet'
ALTER TABLE [dbo].[RadiSet]
ADD CONSTRAINT [PK_RadiSet]
    PRIMARY KEY CLUSTERED ([Racunarski_servisID_servisa], [Serviser_racunaraJMBG_s] ASC);
GO

-- Creating primary key on [RadiRacunarski_servisID_servisa], [RadiServiser_racunaraJMBG_s], [DonosiRacunarski_servisID_servisa], [DonosiPosjedujeVlasnik_racunaraJMBG_vl], [DonosiPosjedujeRacunarID_racunara] in table 'ServisiraSet'
ALTER TABLE [dbo].[ServisiraSet]
ADD CONSTRAINT [PK_ServisiraSet]
    PRIMARY KEY CLUSTERED ([RadiRacunarski_servisID_servisa], [RadiServiser_racunaraJMBG_s], [DonosiRacunarski_servisID_servisa], [DonosiPosjedujeVlasnik_racunaraJMBG_vl], [DonosiPosjedujeRacunarID_racunara] ASC);
GO

-- Creating primary key on [Id_gar_list] in table 'Garantni_listSet'
ALTER TABLE [dbo].[Garantni_listSet]
ADD CONSTRAINT [PK_Garantni_listSet]
    PRIMARY KEY CLUSTERED ([Id_gar_list] ASC);
GO

-- Creating primary key on [ID_servisa] in table 'ServisSet_Racunarski_servis'
ALTER TABLE [dbo].[ServisSet_Racunarski_servis]
ADD CONSTRAINT [PK_ServisSet_Racunarski_servis]
    PRIMARY KEY CLUSTERED ([ID_servisa] ASC);
GO

-- Creating primary key on [ID_servisa] in table 'ServisSet_Servis_mob_tel'
ALTER TABLE [dbo].[ServisSet_Servis_mob_tel]
ADD CONSTRAINT [PK_ServisSet_Servis_mob_tel]
    PRIMARY KEY CLUSTERED ([ID_servisa] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Vlasnik_racunaraJMBG_vl] in table 'PosjedujeSet'
ALTER TABLE [dbo].[PosjedujeSet]
ADD CONSTRAINT [FK_Vlasnik_racunaraPosjeduje]
    FOREIGN KEY ([Vlasnik_racunaraJMBG_vl])
    REFERENCES [dbo].[Vlasnik_racunaraSet]
        ([JMBG_vl])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [KomponentaId_komp] in table 'Sastoji_seSet'
ALTER TABLE [dbo].[Sastoji_seSet]
ADD CONSTRAINT [FK_KomponentaSastoji_se]
    FOREIGN KEY ([KomponentaId_komp])
    REFERENCES [dbo].[KomponentaSet]
        ([Id_komp])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [KomponentaId_komp1] in table 'Sastoji_seSet'
ALTER TABLE [dbo].[Sastoji_seSet]
ADD CONSTRAINT [FK_KomponentaSastoji_se1]
    FOREIGN KEY ([KomponentaId_komp1])
    REFERENCES [dbo].[KomponentaSet]
        ([Id_komp])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KomponentaSastoji_se1'
CREATE INDEX [IX_FK_KomponentaSastoji_se1]
ON [dbo].[Sastoji_seSet]
    ([KomponentaId_komp1]);
GO

-- Creating foreign key on [RacunarID_racunara] in table 'KomponentaSet'
ALTER TABLE [dbo].[KomponentaSet]
ADD CONSTRAINT [FK_RacunarKomponenta]
    FOREIGN KEY ([RacunarID_racunara])
    REFERENCES [dbo].[RacunarSet]
        ([ID_racunara])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RacunarKomponenta'
CREATE INDEX [IX_FK_RacunarKomponenta]
ON [dbo].[KomponentaSet]
    ([RacunarID_racunara]);
GO

-- Creating foreign key on [RacunarID_racunara] in table 'PosjedujeSet'
ALTER TABLE [dbo].[PosjedujeSet]
ADD CONSTRAINT [FK_RacunarPosjeduje]
    FOREIGN KEY ([RacunarID_racunara])
    REFERENCES [dbo].[RacunarSet]
        ([ID_racunara])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RacunarPosjeduje'
CREATE INDEX [IX_FK_RacunarPosjeduje]
ON [dbo].[PosjedujeSet]
    ([RacunarID_racunara]);
GO

-- Creating foreign key on [Racunarski_servisID_servisa] in table 'RadiSet'
ALTER TABLE [dbo].[RadiSet]
ADD CONSTRAINT [FK_Racunarski_servisRadi]
    FOREIGN KEY ([Racunarski_servisID_servisa])
    REFERENCES [dbo].[ServisSet_Racunarski_servis]
        ([ID_servisa])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Serviser_racunaraJMBG_s] in table 'RadiSet'
ALTER TABLE [dbo].[RadiSet]
ADD CONSTRAINT [FK_Serviser_racunaraRadi]
    FOREIGN KEY ([Serviser_racunaraJMBG_s])
    REFERENCES [dbo].[Serviser_racunaraSet]
        ([JMBG_s])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Serviser_racunaraRadi'
CREATE INDEX [IX_FK_Serviser_racunaraRadi]
ON [dbo].[RadiSet]
    ([Serviser_racunaraJMBG_s]);
GO

-- Creating foreign key on [Racunarski_servisID_servisa] in table 'DonosiSet'
ALTER TABLE [dbo].[DonosiSet]
ADD CONSTRAINT [FK_Racunarski_servisDonosi]
    FOREIGN KEY ([Racunarski_servisID_servisa])
    REFERENCES [dbo].[ServisSet_Racunarski_servis]
        ([ID_servisa])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PosjedujeVlasnik_racunaraJMBG_vl], [PosjedujeRacunarID_racunara] in table 'DonosiSet'
ALTER TABLE [dbo].[DonosiSet]
ADD CONSTRAINT [FK_PosjedujeDonosi]
    FOREIGN KEY ([PosjedujeVlasnik_racunaraJMBG_vl], [PosjedujeRacunarID_racunara])
    REFERENCES [dbo].[PosjedujeSet]
        ([Vlasnik_racunaraJMBG_vl], [RacunarID_racunara])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PosjedujeDonosi'
CREATE INDEX [IX_FK_PosjedujeDonosi]
ON [dbo].[DonosiSet]
    ([PosjedujeVlasnik_racunaraJMBG_vl], [PosjedujeRacunarID_racunara]);
GO

-- Creating foreign key on [RadiRacunarski_servisID_servisa], [RadiServiser_racunaraJMBG_s] in table 'ServisiraSet'
ALTER TABLE [dbo].[ServisiraSet]
ADD CONSTRAINT [FK_RadiServisira]
    FOREIGN KEY ([RadiRacunarski_servisID_servisa], [RadiServiser_racunaraJMBG_s])
    REFERENCES [dbo].[RadiSet]
        ([Racunarski_servisID_servisa], [Serviser_racunaraJMBG_s])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [DonosiRacunarski_servisID_servisa], [DonosiPosjedujeVlasnik_racunaraJMBG_vl], [DonosiPosjedujeRacunarID_racunara] in table 'ServisiraSet'
ALTER TABLE [dbo].[ServisiraSet]
ADD CONSTRAINT [FK_DonosiServisira]
    FOREIGN KEY ([DonosiRacunarski_servisID_servisa], [DonosiPosjedujeVlasnik_racunaraJMBG_vl], [DonosiPosjedujeRacunarID_racunara])
    REFERENCES [dbo].[DonosiSet]
        ([Racunarski_servisID_servisa], [PosjedujeVlasnik_racunaraJMBG_vl], [PosjedujeRacunarID_racunara])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DonosiServisira'
CREATE INDEX [IX_FK_DonosiServisira]
ON [dbo].[ServisiraSet]
    ([DonosiRacunarski_servisID_servisa], [DonosiPosjedujeVlasnik_racunaraJMBG_vl], [DonosiPosjedujeRacunarID_racunara]);
GO

-- Creating foreign key on [Garantni_listId_gar_list] in table 'ServisiraSet'
ALTER TABLE [dbo].[ServisiraSet]
ADD CONSTRAINT [FK_ServisiraGarantni_list]
    FOREIGN KEY ([Garantni_listId_gar_list])
    REFERENCES [dbo].[Garantni_listSet]
        ([Id_gar_list])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServisiraGarantni_list'
CREATE INDEX [IX_FK_ServisiraGarantni_list]
ON [dbo].[ServisiraSet]
    ([Garantni_listId_gar_list]);
GO

-- Creating foreign key on [ID_servisa] in table 'ServisSet_Racunarski_servis'
ALTER TABLE [dbo].[ServisSet_Racunarski_servis]
ADD CONSTRAINT [FK_Racunarski_servis_inherits_Servis]
    FOREIGN KEY ([ID_servisa])
    REFERENCES [dbo].[ServisSet]
        ([ID_servisa])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID_servisa] in table 'ServisSet_Servis_mob_tel'
ALTER TABLE [dbo].[ServisSet_Servis_mob_tel]
ADD CONSTRAINT [FK_Servis_mob_tel_inherits_Servis]
    FOREIGN KEY ([ID_servisa])
    REFERENCES [dbo].[ServisSet]
        ([ID_servisa])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------