BEGIN TRAN;

DROP TABLE IF EXISTS ORDER_POSITIONS;
DROP TABLE IF EXISTS ORDER_LISTS;
DROP TABLE IF EXISTS OFFERS;
DROP TABLE IF EXISTS COMPANY_CONTACT_DATA;
DROP TABLE IF EXISTS COMPANY;
DROP TABLE IF EXISTS MATERIAL;

create table COMPANIES
(
    ID          uniqueidentifier not null primary key,
    NAME        text             not null,
    ADDRESS     text             not null,
    CITY        text             not null,
    VOIVODESHIP text             not null
);

create table COMPANY_CONTACT_DATA
(
    Id                              uniqueidentifier not null primary key,
    DESCRIPTION                     text             not null,
    REPRESENTATIVE_NAME_AND_SURNAME text             not null,
    EMAIL_ADDRESS                   text             not null,
    PHONE_NUMBER                    text             not null,
    COMPANY_ID                      uniqueidentifier
        constraint C_DATA_COMPANY_FK
            references COMPANIES
);

create table MATERIALS
(
    ID            uniqueidentifier not null primary key,
    NAME          text             not null,
    SPECIFICATION text             not null
);

create table OFFERS
(
    ID                     uniqueidentifier not null primary key,
    UNIT                   text             not null,
    UNIT_PRICE             decimal(10, 2)   not null check ([UNIT_PRICE] >= 0),
    COMMENTS               text,
    LAST_MODIFICATION_DATE datetime,
    COMPANY_ID             uniqueidentifier not null
        constraint OFFER_COMPANY_FK
            references COMPANIES,
    MATERIAL_ID            uniqueidentifier not null
        constraint OFFER_MATERIAL_FK
            references MATERIALS
);

create table ORDER_LISTS
(
    ID                     uniqueidentifier not null primary key,
    LAST_MODIFICATION_DATE datetime,
    NAME                   text             not null
);

create table ORDER_POSITIONS
(
    ID            uniqueidentifier not null primary key,
    QUANTITY      int              not null check ([QUANTITY] > 0),
    ORDER_LIST_ID uniqueidentifier not null
        constraint POSITION_ORDER_FK
            references ORDER_LISTS,
    MATERIAL_ID   uniqueidentifier not null
        constraint POSITION_OFFER_FK
            references OFFERS
);

COMMIT;
