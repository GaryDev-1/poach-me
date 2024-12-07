-- Test Unique Constraints
SELECT Email, COUNT(*) as Count
FROM Users
GROUP BY Email
HAVING COUNT(*) > 1;

SELECT Username, COUNT(*) as Count
FROM Users
GROUP BY Username
HAVING COUNT(*) > 1;

-- Test Soft Delete
SELECT *
FROM Animals
WHERE IsDeleted = 1;

-- Test Required Fields
SELECT *
FROM Animals
WHERE Name IS NULL
   OR Price IS NULL
   OR LocationId IS NULL
   OR AnimalTypeId IS NULL;