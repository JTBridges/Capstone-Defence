import mysql.connector
import sys
import requests

user = sys.argv[1]
passw = sys.argv[2]

mydb = mysql.connector.connect(
    host= "localhost",
    user= "root",
    passwd= "$punjabi54",
    database= "capstone"
)

cursor = mydb.cursor()
cursor.execute("select username,password from users where username = '%s' and password = '%s'" % (user,passw))
result = cursor.fetchall()

if cursor.rowcount == 0:
    print(0)
else:
    print(1)
