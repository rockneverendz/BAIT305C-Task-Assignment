# Sample Data

| EmployeeID | Username  | Password |
| ---------- | --------- | -------- |
| 1001       | employee1 | 1111aaaa |
| 2002       | employee2 | 2222eeee |
| 3003       | employee3 | 3333cccc |
| 4004       | employee4 | 4444dddd |
| 5005       | employee5 | 5555eeee |

# Update Database

Auto migrations is enabled in this project. But it is still possible to migrate manually.  
 1. Open **Package Manager** console,
 2. `Add-Migration <migration-name>`
 3. `Update-Database`

# Rebuild Database

Delete `(localdb)\MSSQLLocalDB` > `Database` > `Task_Assignment.Data.ApplicationDbContext`.  
If migrations contains files other than `Configuration.cs` delete that as well.

# Troubleshoot

### System.Data.DataException

```
SqlException: Cannot attach the file '...\Task_Assignment\App_Data\Task_Assignment.Data.ApplicationDbContext.mdf' as database 'Task_Assignment.Data.ApplicationDbContext'.
```

Check if `(localdb)\MSSQLLocalDB` > `Database` contains `Task_Assignment.Data.ApplicationDbContext`, if so, delete it.