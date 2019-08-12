from tkinter import *
import  MySQLdb
import register
import update_password
import index
import index_stu

win = Tk()
win.title('登录')
win.geometry('400x200')

#登录函数
def login(index1):
    user = username.get() #获得用户名
    pd = password.get()   #获得密码

    db = MySQLdb.connect("localhost","root","142118","shujuku")
    cursor = db.cursor()
    sql = "select * from USER";

    try:
        cursor.execute(sql)
        results = cursor.fetchall()
    except:
        print("sql exec error!")
    db.close()

    word = 0
    for row in results:
        if((row[0] == user) & (row[1] == pd)):
            word = 1
            break

    if(word == 0):
        win1 = Toplevel()
        win1.title("提示消息")
        win1.geometry("400x200")

        Label(win1, text="账户或者密码输入错误!").place(x = 130, y = 50)
        win1.mainloop()
    elif(word == 1):
        win.destroy()
        if(index1 == 1):
            index.index(user, pd)
        elif(index1 == 2):
            index_stu.index_stu(user,pd)

labelIp = Label(win, text='账号').place(x=10, y=10)
labelPort =Label(win, text='密码').place(x=10, y=50)

username = Variable()
password = Variable()
entryIp = Entry(win, textvariable=username).place(x=150, y=10)
entryPort = Entry(win, textvariable=password, show="*").place(x=150, y=50)

button = Button(win, text="注册", command=register.regis).place(x=30,y=100)
button1 = Button(win, text="教师登录", command=lambda :login(1)).place(x=100,y=100)
button1 = Button(win, text="学生登录", command=lambda :login(2)).place(x=200,y=100)
button2 = Button(win, text="修改密码", command=update_password.update_pd).place(x=300,y=100)
win.mainloop()

