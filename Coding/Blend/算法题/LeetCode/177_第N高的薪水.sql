
--  177. 第N高的薪水
CREATE FUNCTION getNthHighestSalary(N INT) RETURNS INT
BEGIN
  SET n = N-1;
  RETURN (
      # Write your MySQL query statement below.
      
      select distinct Salary from Employee order by Salary desc limit n, 1
      
  );
END