Public Class PlayAnimation

    Friend mPictures As ArrayList
    Friend mRate As Integer

    Private WithEvents mTimer As Timer
    Private WithEvents mCloseTimer As Timer
    Private mIndex As Integer = 0
    Private mImage As Image

    Private Sub PlayAnimation_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            If mTimer IsNot Nothing Then
                mTimer.Stop()
                mTimer = Nothing
            End If
            If Not IsNothing(mCloseTimer) Then
                mCloseTimer.Stop()
                mCloseTimer = Nothing
            End If
            mPictures = Nothing
            pbAnim.Image = Nothing
            If Not IsNothing(mImage) Then
                mImage.Dispose()
                mImage = Nothing
            End If
            Me.Dispose()
        End If
    End Sub

    Private Sub PlayAnimation_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        mIndex = 0
        If Not IsNothing(mImage) Then
            mImage.Dispose()
            mImage = Nothing
        End If
        mImage = Image.FromFile(mPictures.Item(mIndex))
        pbAnim.Image = mImage
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
            If Not IsNothing(mImage) Then
                mImage.Dispose()
                mImage = Nothing
            End If
            mImage = Image.FromFile(mPictures.Item(mIndex))
            pbAnim.Image = mImage
        Else
            mTimer.Stop()
            mTimer = Nothing
            mCloseTimer = New Timer()
            mCloseTimer.Interval = 3000
            mCloseTimer.Start()
        End If
    End Sub

    Private Sub CloseTimerEventProcessor(myObject As Object, ByVal myEventArgs As EventArgs) Handles mCloseTimer.Tick
        If mTimer IsNot Nothing Then
            mTimer.Stop()
            mTimer = Nothing
        End If
        If Not IsNothing(mCloseTimer) Then
            mCloseTimer.Stop()
            mCloseTimer = Nothing
        End If
        mPictures = Nothing
        pbAnim.Image = Nothing
        If Not IsNothing(mImage) Then
            mImage.Dispose()
            mImage = Nothing
        End If
        Me.Dispose()
    End Sub

End Class