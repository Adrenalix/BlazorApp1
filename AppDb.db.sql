BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
	"MigrationId"	TEXT NOT NULL,
	"ProductVersion"	TEXT NOT NULL,
	CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY("MigrationId")
);
CREATE TABLE IF NOT EXISTS "Department" (
	"DepartmentId"	INTEGER NOT NULL,
	"DepartmentName"	TEXT NOT NULL,
	CONSTRAINT "PK_Department" PRIMARY KEY("DepartmentId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Employee" (
	"EmployeeId"	INTEGER NOT NULL,
	"FirstName"	TEXT NOT NULL,
	"LastName"	TEXT NOT NULL,
	"PayrollNumber"	INTEGER NOT NULL,
	"DepartmentId"	INTEGER NOT NULL,
	CONSTRAINT "FK_Employee_Department_DepartmentId" FOREIGN KEY("DepartmentId") REFERENCES "Department"("DepartmentId") ON DELETE CASCADE,
	CONSTRAINT "PK_Employee" PRIMARY KEY("EmployeeId" AUTOINCREMENT)
);
INSERT INTO "__EFMigrationsHistory" VALUES ('20230927101549_FirstMigration','7.0.11');
INSERT INTO "Department" VALUES (1,'IT');
INSERT INTO "Department" VALUES (2,'Sales');
INSERT INTO "Department" VALUES (3,'Marketing');
INSERT INTO "Employee" VALUES (2,'Fredrik','Jonsson',0,1);
INSERT INTO "Employee" VALUES (12,'Mike','Magic!',0,3);
INSERT INTO "Employee" VALUES (13,'Emil','Löjlig',0,2);
INSERT INTO "Employee" VALUES (14,'Nittaya','Jonsson',0,3);
INSERT INTO "Employee" VALUES (15,'Nutcha','Nasa',0,3);
CREATE INDEX IF NOT EXISTS "IX_Employee_DepartmentId" ON "Employee" (
	"DepartmentId"
);
COMMIT;
