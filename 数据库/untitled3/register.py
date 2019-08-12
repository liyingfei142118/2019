from tkinter import *
import MySQLdb

def regis():
    win = Toplevel()
    win.title('注册')
    win.geometry('400x200')

    def create_user(name, password):
        db = MySQLdb.connect("localhost", "root", "142118", "shujuku")
        # 使用cursor()方法获取操作游标
        cursor = db.cursor()
        # SQL 插入语句 注意 占位符和双引号

        sql = """INSERT INTO USER(USERNAME,PASSWORD)
                  VALUES ('%s','%s' )""" % (name, password)
        try:
            # 执行sql语句
            cursor.execute(sql)
            # 提交到数据库执行
            db.commit()
        except:
            db.rollback()

        # 关闭数据库连接
        db.close()

    def register():
        name = username.get()
        print(name)
        pass0 = password.get()
        pass1 = password1.get()
        if (pass0 == pass1):
            create_user(name, pass0)

            win1 = Toplevel()
            win1.title("提示信息")
            win1.geometry('400x200')
            Label(win1, text="注册成功").place(x=10,y=10)
            win1.mainloop()
        else:
            win2 = Toplevel()
            win2.title("ERROR")
            win2.geometry('400x200')
            Label(win2, text="两次输入密码不正确").place(x=10,y=10)
            win2.mainloop()

    Label(win, text='账号').place(x=10, y=10)
    Label(win, text='密码').place(x=10, y=50)
    Label(win, text='确认密码').place(x=10, y=90)

    username = Variable()
    password = Variable()
    password1 = Variable()
    Entry(win, textvariable = username).place(x=150, y=10)
    Entry(win, textvariable = password).place(x=150, y=50)
    Entry(win, textvariable = password1).place(x=150, y=90)

    Button(win, text="注册", command=register).place(x=150, y=120)

    win.mainloop()




