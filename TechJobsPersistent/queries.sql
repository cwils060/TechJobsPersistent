--Part 1
Jobs Table Columns & Data Types

-Id:INT
-Name:longtext
-EmployerId: INT 

--Part 2

Select * From Employers
Where Location = "St. Louis City";

--Part 3
Select skills.Name as Skill_Name, skills.description as SKill_Description
From skills
JOIN JobSkills On skills.Id = JobSkills.skillId
Where Jobskills.JobId IS NOT NULL
Order by skills.Name asc;

