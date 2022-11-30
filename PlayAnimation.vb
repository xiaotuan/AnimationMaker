Public Class PlayAnimation

    Friend mPictures As ArrayList
    Friend mRate As Integer

    Private WithEvents mTimer As Timer
    Private WithEvents mCloseTimer As Timer
    Private mIndex As Integer = 0

    Private Sub PlayAnimation_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            If mTimer IsNot Nothing Then
                mTimer.Stop()
                mTimer = Nothing
            End If
            Me.Close()
        End If
    End Sub

    Private Sub PlayAnimation_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        mIndex = 0
        pbAnim.Image = Image.FromFile(mPictures.Item(mIndex))
        If mTimer IsNot Nothing Then
            mTimer.Stop()
            mTimer = Nothing
        End If
        mTimer = New Timer()
        mTimer.Interval = 1000 \ mRate
        mTimer.Start()
    End Sub

    Private Sub TimerEventProcessor(myObject As Object, ByVal myEventArgs As EventArgs) Handles mTimer.Tick
        mIndex += 1
        If mIndex < mPictures.Count Then
            pbAnim.Image = Image.FromFile(mPictures.Item(mIndex))
        Else
            mTimer.Stop()
            mTimer = Nothing
            mCloseTimer = New Timer()
            mCloseTimer.Interval = 3000
            mCloseTimer.Start()
        End If
    End Sub

    Private Sub CloseTimerEventProcessor(myObject As Object, ByVal myEventArgs As EventArgs) Handles mCloseTimer.Tick
        mCloseTimer.Stop()
        mCloseTimer = Nothing
        Me.Close()
    End Sub

End Class