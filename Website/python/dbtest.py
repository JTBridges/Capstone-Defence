import mysql.connector

mydb = mysql.connector.connect(
    host= "localhost",
    user= "root",
    passwd= "$punjabi54",
    database= "capstone"
)


cursor = mydb.cursor()
cursor.execute("select * from users")
result = cursor.fetchall()
print(result)
