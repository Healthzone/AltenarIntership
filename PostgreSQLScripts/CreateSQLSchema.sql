-- DROP SCHEMA "AltenarIntership";

CREATE SCHEMA "AltenarIntership" AUTHORIZATION pg_database_owner;

-- DROP SEQUENCE "AltenarIntership"."dbo.Categories_categoryid_seq";

CREATE SEQUENCE "AltenarIntership"."dbo.Categories_categoryid_seq"
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 9223372036854775807
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE "AltenarIntership"."dbo.Sports_sportid_seq";

CREATE SEQUENCE "AltenarIntership"."dbo.Sports_sportid_seq"
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 9223372036854775807
	START 1
	CACHE 1
	NO CYCLE;-- "AltenarIntership"."dbo.Sports" definition

-- Drop table

-- DROP TABLE "AltenarIntership"."dbo.Sports";

CREATE TABLE "AltenarIntership"."dbo.Sports" (
	sportid int8 NOT NULL GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 9223372036854775807 START 1 CACHE 1 NO CYCLE),
	sportname varchar NOT NULL,
	CONSTRAINT dbo_sports_pk PRIMARY KEY (sportid)
);


-- "AltenarIntership"."dbo.Categories" definition

-- Drop table

-- DROP TABLE "AltenarIntership"."dbo.Categories";

CREATE TABLE "AltenarIntership"."dbo.Categories" (
	categoryid int8 NOT NULL GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 9223372036854775807 START 1 CACHE 1 NO CYCLE),
	categoryname varchar NOT NULL,
	sportid int8 NULL,
	CONSTRAINT dbo_categories_pk PRIMARY KEY (categoryid),
	CONSTRAINT dbo_categories_fk FOREIGN KEY (sportid) REFERENCES "AltenarIntership"."dbo.Sports"(sportid)
);


-- "AltenarIntership"."dbo.Championships" definition

-- Drop table

-- DROP TABLE "AltenarIntership"."dbo.Championships";

CREATE TABLE "AltenarIntership"."dbo.Championships" (
	championshipid int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	championshipname varchar NOT NULL,
	categoryid int8 NULL,
	CONSTRAINT dbo_championships_pk PRIMARY KEY (championshipid),
	CONSTRAINT dbo_championships_fk FOREIGN KEY (categoryid) REFERENCES "AltenarIntership"."dbo.Categories"(categoryid)
);


-- "AltenarIntership"."dbo.Events" definition

-- Drop table

-- DROP TABLE "AltenarIntership"."dbo.Events";

CREATE TABLE "AltenarIntership"."dbo.Events" (
	eventid int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	eventname varchar NOT NULL,
	eventdate varchar NOT NULL,
	championshipid int8 NULL,
	lastupdate varchar NOT NULL,
	CONSTRAINT dbo_events_pk PRIMARY KEY (eventid),
	CONSTRAINT dbo_events_fk FOREIGN KEY (championshipid) REFERENCES "AltenarIntership"."dbo.Championships"(championshipid)
);


-- "AltenarIntership"."dbo.Markets" definition

-- Drop table

-- DROP TABLE "AltenarIntership"."dbo.Markets";

CREATE TABLE "AltenarIntership"."dbo.Markets" (
	marketid int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	eventid int8 NULL,
	marketname varchar NOT NULL,
	CONSTRAINT dbo_markets_pk PRIMARY KEY (marketid),
	CONSTRAINT dbo_markets_fk FOREIGN KEY (eventid) REFERENCES "AltenarIntership"."dbo.Events"(eventid)
);


-- "AltenarIntership"."dbo.Outcomes" definition

-- Drop table

-- DROP TABLE "AltenarIntership"."dbo.Outcomes";

CREATE TABLE "AltenarIntership"."dbo.Outcomes" (
	outcomeid int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	marketid int8 NULL,
	outcomename varchar NOT NULL,
	price numeric NOT NULL,
	CONSTRAINT dbo_outcomes_pk PRIMARY KEY (outcomeid),
	CONSTRAINT dbo_outcomes_fk FOREIGN KEY (marketid) REFERENCES "AltenarIntership"."dbo.Markets"(marketid)
);