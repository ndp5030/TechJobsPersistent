--Part 1

-- Job Table
-- Id Int PRIMARY KEY
-- Name String
-- EmployerId Int

--Part 2
SELECT * 
FROM techjobs.employers
WHERE Location = "St. Louis City";

--Part 3
SELECT JobId, techjobs.skills.Name, techjobs.skills.Description 
FROM techjobs.jobskills
INNER JOIN techjobs.skills ON techjobs.jobskills.SkillId = techjobs.skills.Id
ORDER BY Name;

-- Why do we need to use is not null when we can inner join?
-- I read the instructions. Not sure if it wants alphabetical by job name or skill name
