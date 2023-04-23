Imports System.Drawing.Imaging
Imports System.IO.Compression

Public Class AnimationMaker

    Public Class PictureCompare
        Implements IComparer

        ' Calls CaseInsensitiveComparer.Compare with the parameters reversed.
        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
         Implements IComparer.Compare
            Dim xobj As String = TryCast(x, String)
            Dim yobj As String = TryCast(y, String)
            If xobj IsNot Nothing And yobj IsNot Nothing Then
                If xobj.Length > yobj.Length Then
                    Return 1
                ElseIf xobj.Length < yobj.Length Then
                    Return -1
                Else
                    Return xobj.CompareTo(yobj)
                End If
            Else
                Throw New ArgumentException("Object is not a String")
            End If
        End Function 'IComparer.Compare

    End Class

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Animation.Directory = ""
        Animation.Pictures = New ArrayList()
        Debug.WriteLine("Number: " + Format(1, "0000"))
    End Sub

    Private Sub tbDirectory_KeyDown(sender As Object, e As KeyEventArgs) Handles tbDirectory.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim directory = Trim(tbDirectory.Text)
            If (Animation.Directory <> directory) Then
                Debug.WriteLine("Directory: " + directory)
                Animation.Directory = directory
                update_Pictures()
                update_ListView()
            End If
        End If
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        If fbdDirectory.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            Debug.WriteLine("Select path: " + fbdDirectory.SelectedPath)
            If fbdDirectory.SelectedPath <> Animation.Directory Then
                Animation.Directory = fbdDirectory.SelectedPath
                tbDirectory.Text = Animation.Directory
                update_Pictures()
                update_ListView()
            End If
        End If
    End Sub

    Private Sub update_ListView()
        If Animation.Pictures.Count <> 0 Then
            lvPictures.Items.Clear()
            Dim i%
            Debug.WriteLine("Picture size: " + Str(Animation.Pictures.Count))
            For i = 0 To Animation.Pictures.Count - 1
                Dim item = New ListViewItem With {
                    .Text = Str(i + 1)
                }

                Dim fileItem = New ListViewItem.ListViewSubItem With {
                    .Text = My.Computer.FileSystem.GetName(Animation.Pictures.Item(i)),
                    .Tag = Animation.Pictures.Item(i)
                }

                item.SubItems.Add(fileItem)
                lvPictures.Items.Add(item)
            Next
        Else
            lvPictures.Items.Clear()
        End If
    End Sub

    Private Shared Sub update_Pictures()
        Animation.Pictures.Clear()
        If System.IO.Directory.Exists(Animation.Directory) Then
            Dim files = System.IO.Directory.EnumerateFiles(Animation.Directory)
            For Each f In files
                Debug.WriteLine("File path: " + f)
                Dim index = f.LastIndexOf(".")
                Dim suffix = ""
                If index <> -1 Then
                    suffix = f.Substring(index)
                End If
                Debug.WriteLine("File suffix: " + suffix)
                suffix = suffix.ToLower()
                If suffix = ".png" Or suffix = ".jpg" Or suffix = ".bmp" Or suffix = ".jpeg" Then
                    Animation.Pictures.Add(f)
                End If
            Next
        Else
            MessageBox.Show("目录：" + Animation.Directory + " 不存在", "提示"， MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Animation.Pictures.Sort(New PictureCompare())
    End Sub

    Private Sub cbReverse_CheckedChanged(sender As Object, e As EventArgs) Handles cbReverse.CheckedChanged
        Animation.Pictures.Reverse()
        update_ListView()
    End Sub

    Private Sub btnRename_Click(sender As Object, e As EventArgs) Handles btnRename.Click
        btnRename.Enabled = False
        Dim prefix = tbPrefix.Text.Trim()
        Dim startNumber = tbNumber.Text.Trim()
        If Len(prefix) > 0 And IsNumeric(startNumber) Then
            Dim start = Int(startNumber)
            Dim bitNumber = Str(Animation.Pictures.Count).Length
            Dim numFormat = ""
            Dim i%
            For i = 1 To bitNumber
                numFormat += "0"
            Next
            For i = 0 To Animation.Pictures.Count - 1
                Dim item = Animation.Pictures.Item(i).ToString()
                Dim path = item.Substring(0, item.LastIndexOf("\"))
                Debug.WriteLine("Path: " + path)
                Dim number = Format(start + i, numFormat)
                path += String.Concat("\", prefix, number, item.AsSpan(item.LastIndexOf(".")))
                Debug.WriteLine("Number: " + number)
                Debug.WriteLine("Source path: " + Animation.Pictures.Item(i) + ", Dest path: " + path)
                System.IO.File.Move(Animation.Pictures.Item(i), path)
            Next
            update_Pictures()
            update_ListView()
        Else
            MessageBox.Show("前缀不能为空，或者起始字符串不是数字", "提示"， MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        btnRename.Enabled = True
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        Dim rateStr = tbRate.Text.Trim()
        If System.IO.Directory.Exists(Animation.Directory) Then
            If IsNumeric(rateStr) Then
                Dim img = Image.FromFile(Animation.Pictures.Item(0))
                Dim imgWidth = img.Width
                Dim imgHeight = img.Height
                img.Dispose()
                img = Nothing
                Dim width = imgWidth
                Dim height = imgHeight
                Dim screenWidth = My.Computer.Screen.Bounds.Width
                Dim screenHeight = My.Computer.Screen.Bounds.Height
                Debug.WriteLine("Screen width: " + Str(screenWidth) + ", height: " + Str(screenHeight))
                If imgWidth > screenWidth Or imgHeight > screenHeight Then
                    Dim wScale = Double.Parse(screenWidth \ 2) / Double.Parse(imgWidth)
                    Dim hScale = Double.Parse(screenHeight \ 2) / Double.Parse(imgHeight)
                    Dim scale = Math.Min(wScale, hScale)
                    Debug.WriteLine("wScale: " + Str(wScale) + ", hScale: " + Str(hScale) + ", scale: " + Str(scale))
                    width = Int(Double.Parse(width) * scale)
                    height = Int(Double.Parse(height) * scale)
                End If
                Debug.WriteLine("width: " + Str(width) + ", height: " + Str(height))
                Dim playForm = New PlayAnimation With {
                    .mPictures = Animation.Pictures,
                    .mRate = Int(rateStr),
                    .Location = New System.Drawing.Size((screenWidth - width) \ 2, (screenHeight - height) \ 2),
                    .ClientSize = New System.Drawing.Size(width, height)
                }
                playForm.pbAnim.Size = New System.Drawing.Size(width, height)
                playForm.ShowDialog()
            Else
                MessageBox.Show("动画速率必须数字", "提示"， MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("动画图片目录不存在", "提示"， MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btCreate_Click(sender As Object, e As EventArgs) Handles btCreate.Click
        btCreate.Enabled = False
        tbDirectory.Enabled = False
        tbRate.Enabled = False
        rbBoot.Enabled = False
        rbShutdown.Enabled = False
        cbReverse.Enabled = False
        tbPrefix.Enabled = False
        tbNumber.Enabled = False
        btnPreview.Enabled = False
        btnSelect.Enabled = False
        btnRename.Enabled = False
        If System.IO.Directory.Exists(Animation.Directory) Then
            If IsNumeric(tbRate.Text) Then
                Dim animDir = Animation.Directory
                Dim zipAnim = Animation.Directory
                If rbBoot.Checked Then
                    animDir += "\bootanimation"
                    zipAnim += "\bootanimation.zip"
                ElseIf rbShutdown.Checked Then
                    animDir += "\shutdownanimation"
                    zipAnim += "\shutdownanimation.zip"
                End If
                If System.IO.Directory.Exists(animDir) Then
                    System.IO.Directory.Delete(animDir, True)
                End If
                System.IO.Directory.CreateDirectory(animDir)
                Dim part0Dir = animDir + "\part0"
                Dim part1Dir = animDir + "\part1"
                System.IO.Directory.CreateDirectory(part0Dir)
                System.IO.Directory.CreateDirectory(part1Dir)

                Dim i%
                For i = 0 To Animation.Pictures.Count - 1
                    Dim item = Animation.Pictures.Item(i)
                    Dim fileName = My.Computer.FileSystem.GetName(item)
                    Dim index = fileName.LastIndexOf(".")
                    If index > 0 Then
                        Dim suffix = fileName.Substring(index + 1).ToLower()
                        Debug.WriteLine("File: " + fileName + ", Suffix: " + suffix)
                        If suffix <> "png" Then
                            Debug.WriteLine("Convert File: " + fileName + " to " + fileName.Substring(0, index) + ".png")
                            Dim bmp As New Bitmap(item.ToString())
                            fileName = fileName.Substring(0, index) + ".png"
                            bmp.Save(part0Dir + "\" + fileName, ImageFormat.Png)
                            If i = Animation.Pictures.Count - 1 Then
                                bmp.Save(part1Dir + "\" + My.Computer.FileSystem.GetName(Animation.Pictures.Item(0)), ImageFormat.Png)
                            End If
                        Else
                            System.IO.File.Copy(item, part0Dir + "\" + fileName)
                            If i = Animation.Pictures.Count - 1 Then
                                System.IO.File.Copy(item, part1Dir + "\" + My.Computer.FileSystem.GetName(Animation.Pictures.Item(0)))
                            End If
                        End If
                    End If
                Next

                Dim descFile = animDir + "\desc.txt"
                'System.IO.File.Create(descFile)
                Dim img = Image.FromFile(Animation.Pictures.Item(0))
                Dim file As New System.IO.StreamWriter(descFile) With {
                    .NewLine = vbLf
                }
                file.WriteLine(String.Format(img.Width) + " " + String.Format(img.Height) + " " + tbRate.Text)
                file.WriteLine("p 1 0 part0")
                file.WriteLine("p 0 0 part1")
                file.WriteLine("")
                file.Close()
                img.Dispose()
                img = Nothing
                If System.IO.File.Exists(zipAnim) Then
                    System.IO.File.Delete(zipAnim)
                End If
                ZipFile.CreateFromDirectory(animDir, zipAnim, CompressionLevel.NoCompression, False)

                System.IO.Directory.Delete(animDir, True)
                MessageBox.Show("动画制作成功", "提示"， MessageBoxButtons.OK)
            Else
                MessageBox.Show("速率必须是数字", "提示"， MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("动画图片目录不存在", "提示"， MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        btCreate.Enabled = True
        tbDirectory.Enabled = True
        tbRate.Enabled = True
        rbBoot.Enabled = True
        rbShutdown.Enabled = True
        cbReverse.Enabled = True
        tbPrefix.Enabled = True
        tbNumber.Enabled = True
        btnPreview.Enabled = True
        btnSelect.Enabled = True
        btnRename.Enabled = True
    End Sub

End Class
