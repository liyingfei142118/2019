from tkinter import *
import  edit_stu
import search_grade
import xuan_ke
import search_xuan_course

def index_stu(username,password):
    root= Tk()
    root.title("学生管理系统")

    frame1 = Frame(root, relief=RAISED, borderwidth=2,bg="red")
    frame1.pack(side=TOP, fill=BOTH, ipadx=300, ipady=0, expand=0)
    img = PhotoImage(file="images/1.gif")
    canvas = Canvas(frame1)
    canvas.create_image(480, 100, image=img)
    canvas.pack(side=LEFT, fill=X,expand=1)

    frame2 = Frame(root, relief=RAISED, borderwidth=2,bg="deepskyblue")
    frame2.pack(side=BOTTOM, fill=BOTH, ipadx=300, ipady=200, expand=0)
    x1=400
    y1=80
    x2 = 140
    y2=50
    Button(frame2, text="修改学生信息", bg="skyblue", command=edit_stu.edit_stu).place(x=x1, y=y1, anchor=W, width=x2, height=y2)
    Button(frame2, text="查询课程成绩", bg="skyblue", command=lambda: search_grade.search_grade(username)).place(x=x1, y=y1+y2, anchor=W, width=x2, height=y2)
    Button(frame2, text="选课", bg="skyblue", command=lambda: xuan_ke.xuan_ke(username)).place(x=x1, y=y1+y2*2, anchor=W, width=x2, height=y2)
    Button(frame2, text="查询已选课程", bg="skyblue", command=lambda: search_xuan_course.xuan_ke(username)).place(x=x1, y=y1+y2*3, anchor=W, width=x2, height=y2)

    frame3 = Frame(root, relief=RAISED, borderwidth=2,bg="lightblue")
    frame3.pack(side=LEFT, fill=X, ipadx=300, ipady=10, expand=1)

    root.mainloop()

#index_stu("1", "2")