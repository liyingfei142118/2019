from tkinter import *
import student
import  course
import select_course
import chose_course

def index(username, password):
    root = Tk()
    root.title("教师管理系统")

    frame1 = Frame(root, relief=RAISED, borderwidth=2,bg="red")
    frame1.pack(side=TOP, fill=BOTH, ipadx=300, ipady=0, expand=0)
    img = PhotoImage(file="images/1.gif")
    canvas = Canvas(frame1)
    canvas.create_image(480, 100, image=img)
    canvas.pack(side=LEFT, fill=X,expand=1)

    frame2 = Frame(root, relief=RAISED, borderwidth=2,bg="deepskyblue")
    frame2.pack(side=BOTTOM, fill=BOTH, ipadx=300, ipady=200, expand=0)
    x1=400
    x2=130
    y1=130
    y2=130
    Button(frame2, text="学生信息管理", bg="skyblue", command=student.student).place(x=x1, y=y1, anchor=W, width=x2, height=y2)
    Button(frame2, text="课程信息管理", bg="skyblue", command=course.course).place(x=x1+x2, y=y1, anchor=W, width=x2, height=y2)
    Button(frame2, text="学生选课管理", bg="skyblue", command=select_course.select_course).place(x=x1, y=y1+y2, anchor=W, width=x2, height=y2)
    Button(frame2, text="可选课程", bg="skyblue", command=chose_course.chose_course).place(x=x1+x2, y=y1+y2, anchor=W, width=x2, height=y2)

    frame3 = Frame(root, relief=RAISED, borderwidth=2,bg="lightblue")
    frame3.pack(side=LEFT, fill=X, ipadx=300, ipady=10, expand=1)


    root.mainloop()

#index("1", "2")