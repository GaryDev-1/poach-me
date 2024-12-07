-- Test Animal Images
SELECT a.Name AS AnimalName,
       COUNT(ai.Id) AS ImageCount,
       SUM(CASE WHEN ai.IsPrimary = 1 THEN 1 ELSE 0 END) AS PrimaryImageCount
FROM Animals a
LEFT JOIN AnimalImages ai ON a.Id = ai.AnimalId
GROUP BY a.Name;

-- Test Role Permissions
SELECT r.Name AS RoleName,
       COUNT(up.Id) AS PermissionCount,
       STRING_AGG(up.Permission, ', ') AS Permissions
FROM Roles r
LEFT JOIN UserPermissions up ON r.Id = up.RoleId
GROUP BY r.Name;