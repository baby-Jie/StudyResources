select score, @a := @a + (@pre <> (@pre := Score)) as rank 
from scores,(select @a := 0, @pre := -1) t 
order by score desc; 