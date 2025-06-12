-- Table: PlanType
CREATE TABLE PlanType (
    Id TEXT PRIMARY KEY,
    Name TEXT NOT NULL,
    Description TEXT
);

-- Table: PlanPurpose
CREATE TABLE PlanPurpose (
    Id TEXT PRIMARY KEY,
    Name TEXT NOT NULL,
    Description TEXT
);

-- Table: PlanStatus (assumed)
CREATE TABLE PlanStatus (
    Id TEXT PRIMARY KEY,
    Name TEXT NOT NULL,
    Description TEXT
);

-- Table: Plan
CREATE TABLE Plan (
    Id TEXT PRIMARY KEY,
    Name TEXT NOT NULL,
    Description TEXT,
    PlanTypeId TEXT NOT NULL,
	PlanPurposeId Text NULL,
    FromDateTime TEXT NOT NULL,
    ToDateTime TEXT NOT NULL,
    PlanStatusId TEXT NOT NULL,
    FOREIGN KEY (PlanTypeId) REFERENCES PlanType(Id),
    FOREIGN KEY (PlanStatusId) REFERENCES PlanStatus(Id)
);
