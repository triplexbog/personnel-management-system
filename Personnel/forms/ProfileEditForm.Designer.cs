using System;
using System.Windows.Forms;

partial class ProfileEditForm
{
    private System.ComponentModel.IContainer components = null;

    private TabControl tabControl;
    private TabPage tabPersonalInfo;
    private TabPage tabPassportSNILS;
    private TabPage tabContacts;
    private Button btnSave;
    private Button btnCancel;

    // Основные
    private Label lblLastName;
    private Label lblFirstName;
    private Label lblMiddleName;
    private Label lblBirthDate;
    private Label lblGender;
    private Label lblProfileType;
    private Label lblIsActive;
    private TextBox txtLastName;
    private TextBox txtFirstName;
    private TextBox txtMiddleName;
    private DateTimePicker dtpBirthDate;
    private ComboBox cmbGender;
    private ComboBox cmbProfileType;
    private CheckBox chkIsActive;

    // Паспорт/СНИЛС
    private Label lblPassport;
    private Label lblSNILS;
    private Label lblINN;
    private MaskedTextBox txtPassport;
    private MaskedTextBox txtSNILS;
    private MaskedTextBox txtINN;

    // Контакты
    private Label lblPhone;
    private Label lblEmail;
    private Label lblAddress;
    private TextBox txtPhone;
    private TextBox txtEmail;
    private TextBox txtAddress;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.tabControl = new TabControl();
        this.tabPersonalInfo = new TabPage("Основные");
        this.tabPassportSNILS = new TabPage("Паспорт/СНИЛС");
        this.tabContacts = new TabPage("Контакты");

        // Основные
        this.lblLastName = new Label();
        this.txtLastName = new TextBox();
        this.lblFirstName = new Label();
        this.txtFirstName = new TextBox();
        this.lblMiddleName = new Label();
        this.txtMiddleName = new TextBox();
        this.lblBirthDate = new Label();
        this.dtpBirthDate = new DateTimePicker();
        this.lblGender = new Label();
        this.cmbGender = new ComboBox();
        this.lblProfileType = new Label();
        this.cmbProfileType = new ComboBox();
        this.lblIsActive = new Label();
        this.chkIsActive = new CheckBox();

        // Паспорт/СНИЛС
        this.lblPassport = new Label();
        this.txtPassport = new MaskedTextBox();
        this.lblSNILS = new Label();
        this.txtSNILS = new MaskedTextBox();
        this.lblINN = new Label();
        this.txtINN = new MaskedTextBox();

        // Контакты
        this.lblPhone = new Label();
        this.txtPhone = new TextBox();
        this.lblEmail = new Label();
        this.txtEmail = new TextBox();
        this.lblAddress = new Label();
        this.txtAddress = new TextBox();

        this.btnSave = new Button();
        this.btnCancel = new Button();

        // Установим свойства элементов управления (например, текст, размеры и т.д.)
        // Основные
        this.lblLastName.Text = "Фамилия:";
        this.lblLastName.Location = new System.Drawing.Point(20, 20);
        this.lblLastName.Width = 100;

        this.txtLastName.Location = new System.Drawing.Point(130, 20);
        this.txtLastName.Width = 250;

        this.lblFirstName.Text = "Имя:";
        this.lblFirstName.Location = new System.Drawing.Point(20, 60);
        this.lblFirstName.Width = 100;

        this.txtFirstName.Location = new System.Drawing.Point(130, 60);
        this.txtFirstName.Width = 250;

        this.lblMiddleName.Text = "Отчество:";
        this.lblMiddleName.Location = new System.Drawing.Point(20, 100);
        this.lblMiddleName.Width = 100;

        this.txtMiddleName.Location = new System.Drawing.Point(130, 100);
        this.txtMiddleName.Width = 250;

        this.lblBirthDate.Text = "Дата рождения:";
        this.lblBirthDate.Location = new System.Drawing.Point(20, 140);
        this.lblBirthDate.Width = 100;

        this.dtpBirthDate.Location = new System.Drawing.Point(130, 140);
        this.dtpBirthDate.Width = 250;

        this.lblGender.Text = "Пол:";
        this.lblGender.Location = new System.Drawing.Point(20, 180);
        this.lblGender.Width = 100;

        this.cmbGender.Location = new System.Drawing.Point(130, 180);
        this.cmbGender.Width = 150;
        this.cmbGender.Items.AddRange(new object[] { "M", "F" });

        this.lblProfileType.Text = "Тип профиля:";
        this.lblProfileType.Location = new System.Drawing.Point(20, 220);
        this.lblProfileType.Width = 100;

        this.cmbProfileType.Location = new System.Drawing.Point(130, 220);
        this.cmbProfileType.Width = 150;
        this.cmbProfileType.Items.AddRange(new object[] { "Ученик", "Сотрудник" });

        this.lblIsActive.Text = "Активен:";
        this.lblIsActive.Location = new System.Drawing.Point(20, 260);
        this.lblIsActive.Width = 100;

        this.chkIsActive.Location = new System.Drawing.Point(130, 260);
        this.chkIsActive.Text = "Активен";

        // Паспорт/СНИЛС
        this.lblPassport.Text = "Паспорт:";
        this.lblPassport.Location = new System.Drawing.Point(20, 40);
        this.lblPassport.Width = 100;

        this.txtPassport.Location = new System.Drawing.Point(130, 40);
        this.txtPassport.Mask = "0000 000000";
        this.txtPassport.Width = 250;

        this.lblSNILS.Text = "СНИЛС:";
        this.lblSNILS.Location = new System.Drawing.Point(20, 80);
        this.lblSNILS.Width = 100;

        this.txtSNILS.Location = new System.Drawing.Point(130, 80);
        this.txtSNILS.Mask = "000-000-000 00";
        this.txtSNILS.Width = 250;

        this.lblINN.Text = "ИНН:";
        this.lblINN.Location = new System.Drawing.Point(20, 120);
        this.lblINN.Width = 100;

        this.txtINN.Location = new System.Drawing.Point(130, 120);
        this.txtINN.Mask = "000000000000";
        this.txtINN.Width = 250;

        // Контакты
        this.lblPhone.Text = "Телефон:";
        this.lblPhone.Location = new System.Drawing.Point(20, 40);
        this.lblPhone.Width = 100;

        this.txtPhone.Location = new System.Drawing.Point(130, 40);
        this.txtPhone.Width = 250;

        this.lblEmail.Text = "Email:";
        this.lblEmail.Location = new System.Drawing.Point(20, 80);
        this.lblEmail.Width = 100;

        this.txtEmail.Location = new System.Drawing.Point(130, 80);
        this.txtEmail.Width = 250;

        this.lblAddress.Text = "Адрес:";
        this.lblAddress.Location = new System.Drawing.Point(20, 120);
        this.lblAddress.Width = 100;

        this.txtAddress.Location = new System.Drawing.Point(130, 120);
        this.txtAddress.Width = 350;
        this.txtAddress.Multiline = true;
        this.txtAddress.Height = 80;

        // Добавляем элементы на вкладки
        this.tabPersonalInfo.Controls.AddRange(new Control[] {
            this.lblLastName, this.txtLastName, this.lblFirstName, this.txtFirstName, this.lblMiddleName, this.txtMiddleName,
            this.lblBirthDate, this.dtpBirthDate, this.lblGender, this.cmbGender, this.lblProfileType, this.cmbProfileType, this.lblIsActive, this.chkIsActive
        });

        this.tabPassportSNILS.Controls.AddRange(new Control[] {
            this.lblPassport, this.txtPassport, this.lblSNILS, this.txtSNILS, this.lblINN, this.txtINN
        });

        this.tabContacts.Controls.AddRange(new Control[] {
            this.lblPhone, this.txtPhone, this.lblEmail, this.txtEmail, this.lblAddress, this.txtAddress
        });

        // Настройка вкладок
        this.tabControl.Controls.AddRange(new Control[] {
            this.tabPersonalInfo, this.tabPassportSNILS, this.tabContacts
        });

        this.tabControl.Dock = DockStyle.Top;
        this.tabControl.Height = 350;

        // Кнопки
        this.btnSave.Text = "Сохранить";
        this.btnSave.Location = new System.Drawing.Point(150, 370);
        this.btnSave.Click += new EventHandler(this.btnSave_Click);

        this.btnCancel.Text = "Отмена";
        this.btnCancel.Location = new System.Drawing.Point(260, 370);
        this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

        // Добавляем элементы управления на форму
        this.Controls.Add(this.tabControl);
        this.Controls.Add(this.btnSave);
        this.Controls.Add(this.btnCancel);

        // Настроим параметры формы
        this.Text = "Редактирование профиля";
        this.ClientSize = new System.Drawing.Size(500, 420);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.StartPosition = FormStartPosition.CenterParent;
    }
}
