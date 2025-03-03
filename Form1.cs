using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MyHomeworkApp
{
    // 간단한 "하루 숙제 체크" WinForms 폼 예시
    public partial class Form1 : Form
    {
        // 숙제 목록을 관리할 리스트
        private List<HomeworkTask> _tasks;

        // UI 컨트롤들
        private TextBox txtTaskDescription;
        private DateTimePicker dtpTaskDate;
        private Button btnAddTask;
        private Button btnMarkDone;
        private ListBox lstTasks;

        public Form1()
        {
            // 폼 초기화
            InitializeControls();

            // 숙제 리스트 생성
            _tasks = new List<HomeworkTask>();
        }

        private void InitializeControls()
        {
            // 폼 설정
            this.Text = "하루 숙제 체크 앱";
            this.Size = new Size(600, 400);

            // TextBox (숙제 내용 입력)
            txtTaskDescription = new TextBox();
            txtTaskDescription.Location = new Point(20, 20);
            txtTaskDescription.Size = new Size(200, 25);
            this.Controls.Add(txtTaskDescription);

            // DateTimePicker (날짜 선택)
            dtpTaskDate = new DateTimePicker();
            dtpTaskDate.Location = new Point(230, 20);
            dtpTaskDate.Size = new Size(200, 25);
            this.Controls.Add(dtpTaskDate);

            // 추가 버튼
            btnAddTask = new Button();
            btnAddTask.Text = "추가";
            btnAddTask.Location = new Point(440, 20);
            btnAddTask.Click += BtnAddTask_Click;
            this.Controls.Add(btnAddTask);

            // 완료 체크 버튼
            btnMarkDone = new Button();
            btnMarkDone.Text = "완료 체크";
            btnMarkDone.Location = new Point(440, 60);
            btnMarkDone.Click += BtnMarkDone_Click;
            this.Controls.Add(btnMarkDone);

            // ListBox (숙제 목록 표시)
            lstTasks = new ListBox();
            lstTasks.Location = new Point(20, 60);
            lstTasks.Size = new Size(400, 250);
            this.Controls.Add(lstTasks);
        }

        // "추가" 버튼 클릭 이벤트
        private void BtnAddTask_Click(object sender, EventArgs e)
        {
            string desc = txtTaskDescription.Text.Trim();
            if (string.IsNullOrWhiteSpace(desc))
            {
                MessageBox.Show("숙제 내용을 입력하세요.", "알림");
                return;
            }

            // 새로운 숙제 객체 생성
            HomeworkTask newTask = new HomeworkTask(dtpTaskDate.Value.Date, desc);
            _tasks.Add(newTask);

            // ListBox에 표시
            lstTasks.Items.Add($"{newTask.Date.ToShortDateString()} | {newTask.Description} | Done: {newTask.Done}");

            // 입력 필드 리셋
            txtTaskDescription.Text = string.Empty;
            dtpTaskDate.Value = DateTime.Now;
        }

        // "완료 체크" 버튼 클릭 이벤트
        private void BtnMarkDone_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex < 0)
            {
                MessageBox.Show("완료 처리할 숙제를 선택하세요.", "알림");
                return;
            }

            // 선택된 항목의 인덱스로 _tasks 리스트의 해당 객체에 접근
            int index = lstTasks.SelectedIndex;
            _tasks[index].Done = true;

            // ListBox 항목을 갱신 (간단하게 다시 추가)
            lstTasks.Items[index] =
                $"{_tasks[index].Date.ToShortDateString()} | {_tasks[index].Description} | Done: {_tasks[index].Done}";
        }
    }

    // 숙제 정보 모델 클래스
    public class HomeworkTask
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }

        public HomeworkTask(DateTime date, string description)
        {
            Date = date;
            Description = description;
            Done = false;
        }
    }
}
