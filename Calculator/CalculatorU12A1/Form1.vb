Public Class Form1

    Dim ADD As Integer
    Dim SUBTRACT As Integer
    Dim LoopCount As Integer
    Dim Total As Long
    Dim FirstNumber As Long
    Dim FirstChar As Integer

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles butCancelLastEntry.Click
        EnterNumber.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button0.Click, Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click,
        Button7.Click, Button8.Click, Button9.Click

        Dim myButton As Button = CType(sender, Button)

        If FirstChar = 0 And myButton.Text = 0 Then
            EnterNumber.Text = ""
        Else
            EnterNumber.Text = EnterNumber.Text + myButton.Text
            FirstChar = 1
        End If

    End Sub

    Private Sub Minus_Click(sender As Object, e As EventArgs) Handles Minus.Click

        SUBTRACT = 1
        If FirstNumber = 0 Then
            Total = Val(EnterNumber.Text)
            FirstNumber = 1
        Else
            Total = Total - Val(EnterNumber.Text)

        End If
        EnterNumber.Text = ""
        FirstChar = 0
    End Sub

    Private Sub Plus_Click(sender As Object, e As EventArgs) Handles Plus.Click
        ADD = 1                                                 'Set ADD equal to 1, so that when the equals is pressed the code knows to add in the result sub
        If FirstNumber = 0 Then                                 'If 0 then the first number in the set of numbers to be added to has been entered and the user
            Total = Val(EnterNumber.Text)                       'has pressed +. The first number is treated differently from the subsequent numbers
            FirstNumber = 1                                     'set to one and then test is else next time so it is only subsequent numbers that satisfy this
        Else
            Total = Total + Val(EnterNumber.Text)

        End If
        EnterNumber.Text = ""
        FirstChar = 0
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles butReset.Click
        EnterNumber.Text = ""                                   'initialise the input box ready for the next number to be input
        FirstChar = 0                                           'Set this to 0 to prevent the input of leading zeros when the next number is input
        FirstNumber = 0
        Total = 0
        ADD = 0
        SUBTRACT = 0
        Total = 0

        Dim myTxt As Button
        For Each ctl As Control In Me.Controls
            If TypeOf ctl Is Button Then
                myTxt = CType(ctl, Button)
                myTxt.Enabled = "True"
            End If
        Next

    End Sub

    Private Sub Result_Click(sender As Object, e As EventArgs) Handles Result.Click
        FirstNumber = 0                                         'This needs to be reset to zero as the next number will be the first one again

        If ADD = 1 Then
            Total = Total + Val(EnterNumber.Text)               'The last entered number needs to be added to the total as it has not been added if the user
            'has pressed =
            ADD = 0                                             'Turns the ADD switch off ready for next input
        ElseIf SUBTRACT = 1 Then
            Total = Total - Val(EnterNumber.Text)               'The last entered number needs to be subtrated from the total as it has not been
            'if the user has pressed =
            SUBTRACT = 0
        End If
        EnterNumber.Text = CStr(Total)
        FirstChar = 0

        Dim myTxt As Button
        For Each ctl As Control In Controls
            If TypeOf ctl Is Button Then
                myTxt = CType(ctl, Button)
                myTxt.Enabled = "False"
            End If
            butReset.Enabled = "True"
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
