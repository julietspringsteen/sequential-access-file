'***********************************************************
' Author: Juliet Springsteen
' Intro to Programming
' Professor Allen Pearson
' 4.2.2015
'***********************************************************


Imports System.IO

Public Class Form1

    Private myNumbers(50) As Integer
    Private Counter As Integer

  

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sr As New System.IO.StreamReader("NumberData.txt") 'needs to be case sensitive, exact
        Dim rec As String
        Dim position As Integer ' keeps track of position in array
        Dim sum As Integer
        Dim sequenceCount As Integer
        Dim totalSum As Decimal
        Dim totalCount As Integer
        Dim average As Decimal
        Dim totalAverage As Decimal ' declares variables

        rec = sr.ReadLine.ToString ' priming read

        Do While sr.Peek <> -1 ' "not EOF" in Visual Basic, Java, C++
            'ListBox1.Items.Add(rec)
            myNumbers(Counter) = rec
            Counter += 1
            rec = sr.ReadLine.ToString ' read the next record
        Loop

        Do While position < Counter + 1     ' loop to go through array and get averages of each section
            If myNumbers(position) <> 0 Then
                sum = sum + myNumbers(position)   'if the number is not zero, take sum of numbers 
                sequenceCount += 1                ' and count the numbers in the sequence

            Else
                average = sum / sequenceCount               ' once you get to zero, take the average
                ListBox1.Items.Add("Average: " & average)   ' print the average
                totalSum += average                         ' add the average to the total sum
                totalCount += 1                             ' add up number of sequences
                sum = 0
                sequenceCount = 0                           ' sets sum and sequence count back to zero

            End If

            position += 1                                   ' move to the next position and repeat

        Loop

        totalAverage = totalSum / totalCount                ' get total average

        ListBox1.Items.Add("The Total Sum is " & totalSum)
        ListBox1.Items.Add("The average of averages is " & totalAverage)    ' print total average and total sum

        'ListBox1.Items.Add(rec)
        'ListBox1.Items.Add(Counter & "records read")
        'myNumbers(Counter) = rec
        'Counter += 1


        sr.Close()                                          ' close file
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ListBox1.Items.Clear()
    End Sub
End Class
