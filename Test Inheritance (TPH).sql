-- Test Dog-specific fields
SELECT a.Name, a.AnimalType, a.Breed, a.IsTrainable
FROM Animals a
WHERE a.AnimalType = 'Dog';

-- Test Tiger-specific fields
SELECT a.Name, a.AnimalType, a.Subspecies, a.IsWild
FROM Animals a
WHERE a.AnimalType = 'Tiger';

-- Test Fish-specific fields
SELECT a.Name, a.AnimalType, a.Species, a.WaterType, a.OptimalTemperature
FROM Animals a
WHERE a.AnimalType = 'Fish';