-- Test Animal to AnimalType Relationship
SELECT a.Name AS AnimalName, 
       a.AnimalType AS AnimalCategory,
       at.Name AS TypeName, 
       at.Category
FROM Animals a
JOIN AnimalTypes at ON a.AnimalTypeId = at.Id;

-- Test Animal to Location Relationship
SELECT a.Name AS AnimalName, 
       l.Name AS LocationName,
       l.City,
       l.Country
FROM Animals a
JOIN Locations l ON a.LocationId = l.Id;

-- Test User to Role Relationship
SELECT u.Username, 
       u.Email,
       r.Name AS RoleName
FROM Users u
JOIN Roles r ON u.RoleId = r.Id;