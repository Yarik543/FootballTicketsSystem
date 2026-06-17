using FootballTicketsSystem.AppServices;
using FootballTicketsSystem.DBModels;
using FootballTicketsSystem.Helpers;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballTicketsSystem.AppForms
{
    public partial class TeamDetailsForm : Form
    {

        private Teams _currentTeam;
        private Coaches _currentCoach;
        private List<Players> _players;
        private int _selectedIndex = 0;
        private List<Guna2PictureBox> _playerThumbnails = new List<Guna2PictureBox>();
        private List<Guna2Panel> _thumbnailContainers = new List<Guna2Panel>();

        // Словарь для перевода позиций
        private readonly Dictionary<string, string> _positionTranslations = new Dictionary<string, string>
        {
            { "Goalkeeper", "Вратарь" },
            { "Defender", "Защитник" },
            { "Midfielder", "Полузащитник" },
            { "Attacker", "Нападающий" },
            { "Forward", "Нападающий" }
        };

        // Словарь для перевода стран (без дубликатов)
        private readonly Dictionary<string, string> _countryTranslations = new Dictionary<string, string>
{
    { "Spain", "Испания" },
    { "Germany", "Германия" },
    { "France", "Франция" },
    { "England", "Англия" },
    { "Portugal", "Португалия" },
    { "Brazil", "Бразилия" },
    { "Argentina", "Аргентина" },
    { "Netherlands", "Нидерланды" },
    { "Belgium", "Бельгия" },
    { "Croatia", "Хорватия" },
    { "Serbia", "Сербия" },
    { "Uruguay", "Уругвай" },
    { "Morocco", "Марокко" },
    { "Senegal", "Сенегал" },
    { "Algeria", "Алжир" },
    { "Tunisia", "Тунис" },
    { "Nigeria", "Нигерия" },
    { "Cameroon", "Камерун" },  
    { "Ghana", "Гана" },
    { "Ivory Coast", "Кот-д'Ивуар" },
    { "Mali", "Мали" },
    { "Japan", "Япония" },
    { "South Korea", "Южная Корея" },
    { "Australia", "Австралия" },
    { "USA", "США" },
    { "Canada", "Канада" },
    { "Mexico", "Мексика" },
    { "Colombia", "Колумбия" },
    { "Chile", "Чили" },
    { "Peru", "Перу" },
    { "Ecuador", "Эквадор" },
    { "Paraguay", "Парагвай" },
    { "Bolivia", "Боливия" },
    { "Venezuela", "Венесуэла" },
    { "Italy", "Италия" },
    { "Austria", "Австрия" },
    { "Switzerland", "Швейцария" },
    { "Poland", "Польша" },
    { "Czech Republic", "Чехия" },
    { "Slovakia", "Словакия" },
    { "Hungary", "Венгрия" },
    { "Romania", "Румыния" },
    { "Bulgaria", "Болгария" },
    { "Greece", "Греция" },
    { "Turkey", "Турция" },
    { "Russia", "Россия" },
    { "Ukraine", "Украина" },
    { "Belarus", "Беларусь" },
    { "Lithuania", "Литва" },
    { "Latvia", "Латвия" },
    { "Estonia", "Эстония" },
    { "Finland", "Финляндия" },
    { "Sweden", "Швеция" },
    { "Norway", "Норвегия" },
    { "Denmark", "Дания" },
    { "Iceland", "Исландия" },
    { "Scotland", "Шотландия" },
    { "Wales", "Уэльс" },
    { "Northern Ireland", "Северная Ирландия" },
    { "Republic of Ireland", "Ирландия" },
    { "Slovenia", "Словения" },
    { "Bosnia and Herzegovina", "Босния и Герцеговина" },
    { "Montenegro", "Черногория" },
    { "North Macedonia", "Северная Македония" },
    { "Albania", "Албания" },
    { "Kosovo", "Косово" },
    { "Moldova", "Молдова" },
    { "Georgia", "Грузия" },
    { "Armenia", "Армения" },
    { "Azerbaijan", "Азербайджан" },
    { "Kazakhstan", "Казахстан" },
    { "Uzbekistan", "Узбекистан" },
    { "Turkmenistan", "Туркменистан" },
    { "Kyrgyzstan", "Кыргызстан" },
    { "Tajikistan", "Таджикистан" },
    { "Afghanistan", "Афганистан" },
    { "Iran", "Иран" },
    { "Iraq", "Ирак" },
    { "Saudi Arabia", "Саудовская Аравия" },
    { "United Arab Emirates", "ОАЭ" },
    { "Qatar", "Катар" },
    { "Bahrain", "Бахрейн" },
    { "Kuwait", "Кувейт" },
    { "Oman", "Оман" },
    { "Jordan", "Иордания" },
    { "Lebanon", "Ливан" },
    { "Syria", "Сирия" },
    { "Palestine", "Палестина" },
    { "Israel", "Израиль" },
    { "Egypt", "Египет" },
    { "Libya", "Ливия" },
    { "Sudan", "Судан" },
    { "Ethiopia", "Эфиопия" },
    { "Kenya", "Кения" },
    { "Uganda", "Уганда" },
    { "Tanzania", "Танзания" },
    { "Rwanda", "Руанда" },
    { "Burundi", "Бурунди" },
    { "Democratic Republic of the Congo", "ДР Конго" },
    { "Republic of the Congo", "Республика Конго" },
    { "Central African Republic", "ЦАР" },
    { "Chad", "Чад" },
    { "Niger", "Нигер" },
    { "Burkina Faso", "Буркина-Фасо" },
    { "Guinea", "Гвинея" },
    { "Guinea-Bissau", "Гвинея-Бисау" },
    { "Sierra Leone", "Сьерра-Леоне" },
    { "Liberia", "Либерия" },
    { "Côte d'Ivoire", "Кот-д'Ивуар" },
    { "Gambia", "Гамбия" },
    { "Cape Verde", "Кабо-Верде" },
    { "Mauritania", "Мавритания" },
    { "Western Sahara", "Западная Сахара" },
    { "South Africa", "ЮАР" },
    { "Namibia", "Намибия" },
    { "Botswana", "Ботсвана" },
    { "Zimbabwe", "Зимбабве" },
    { "Zambia", "Замбия" },
    { "Malawi", "Малави" },
    { "Mozambique", "Мозамбик" },
    { "Madagascar", "Мадагаскар" },
    { "Mauritius", "Маврикий" },
    { "Seychelles", "Сейшелы" },
    { "Comoros", "Коморы" },
    { "Mayotte", "Майотта" },
    { "Réunion", "Реюньон" },
    { "Lesotho", "Лесото" },
    { "Eswatini", "Эсватини" },
    { "Angola", "Ангола" },
    { "Gabon", "Габон" },
    { "Equatorial Guinea", "Экваториальная Гвинея" }, 
    { "São Tomé and Príncipe", "Сан-Томе и Принсипи" },
    { "Benin", "Бенин" },
    { "Togo", "Того" },
    { "China", "Китай" },
    { "India", "Индия" },
    { "Indonesia", "Индонезия" },
    { "Malaysia", "Малайзия" },
    { "Singapore", "Сингапур" },
    { "Thailand", "Таиланд" },
    { "Vietnam", "Вьетнам" },
    { "Philippines", "Филиппины" },
    { "Myanmar", "Мьянма" },
    { "Cambodia", "Камбоджа" },
    { "Laos", "Лаос" },
    { "Brunei", "Бруней" },
    { "Timor-Leste", "Восточный Тимор" },
    { "Bangladesh", "Бангладеш" },
    { "Pakistan", "Пакистан" },
    { "Sri Lanka", "Шри-Ланка" },
    { "Nepal", "Непал" },
    { "Bhutan", "Бутан" },
    { "Maldives", "Мальдивы" },
    { "Mongolia", "Монголия" },
    { "North Korea", "Северная Корея" },
    { "Hong Kong", "Гонконг" },
    { "Macau", "Макао" },
    { "Taiwan", "Тайвань" },
    { "New Zealand", "Новая Зеландия" },
    { "Fiji", "Фиджи" },
    { "Papua New Guinea", "Папуа - Новая Гвинея" },
    { "Solomon Islands", "Соломоновы Острова" },
    { "Vanuatu", "Вануату" },
    { "New Caledonia", "Новая Каледония" },
    { "French Polynesia", "Французская Полинезия" },
    { "Samoa", "Самоа" },
    { "Tonga", "Тонга" },
    { "Kiribati", "Кирибати" },
    { "Tuvalu", "Тувалу" },
    { "Nauru", "Науру" },
    { "Palau", "Палау" },
    { "Marshall Islands", "Маршалловы Острова" },
    { "Micronesia", "Микронезия" },
    { "Guam", "Гуам" },
    { "Northern Mariana Islands", "Северные Марианские острова" },
    { "American Samoa", "Американское Самоа" },
    { "Cook Islands", "Острова Кука" },
    { "Niue", "Ниуэ" },
    { "Tokelau", "Токелау" },
    { "Pitcairn Islands", "Острова Питкэрн" },
    { "Wallis and Futuna", "Уоллис и Футуна" },
    { "Norfolk Island", "Остров Норфолк" },
    { "Christmas Island", "Остров Рождества" },
    { "Cocos Islands", "Кокосовые острова" },
    { "Heard Island and McDonald Islands", "Остров Херд и острова Макдональд" },
    { "British Indian Ocean Territory", "Британская территория в Индийском океане" },
    { "French Southern Territories", "Французские Южные территории" },
    { "Antarctica", "Антарктида" },
    { "Bouvet Island", "Остров Буве" },
    { "South Georgia and the South Sandwich Islands", "Южная Георгия и Южные Сандвичевы острова" },
    { "Falkland Islands", "Фолклендские острова" },
    { "Saint Helena", "Остров Святой Елены" },
    { "Ascension Island", "Остров Вознесения" },
    { "Tristan da Cunha", "Тристан-да-Кунья" },
    { "Svalbard and Jan Mayen", "Шпицберген и Ян-Майен" },
    { "Åland Islands", "Аландские острова" },
    { "Faroe Islands", "Фарерские острова" },
    { "Greenland", "Гренландия" },
    { "Bermuda", "Бермуды" },
    { "Turks and Caicos Islands", "Острова Теркс и Кайкос" },
    { "British Virgin Islands", "Британские Виргинские острова" },
    { "United States Virgin Islands", "Виргинские острова США" },
    { "Anguilla", "Ангилья" },
    { "Montserrat", "Монтсеррат" },
    { "Antigua and Barbuda", "Антигуа и Барбуда" },
    { "Saint Kitts and Nevis", "Сент-Китс и Невис" },
    { "Dominica", "Доминика" },
    { "Saint Lucia", "Сент-Люсия" },
    { "Saint Vincent and the Grenadines", "Сент-Винсент и Гренадины" },
    { "Barbados", "Барбадос" },
    { "Grenada", "Гренада" },
    { "Trinidad and Tobago", "Тринидад и Тобаго" },
    { "Aruba", "Аруба" },
    { "Curaçao", "Кюрасао" },
    { "Sint Maarten", "Синт-Мартен" },
    { "Bonaire", "Бонайре" },
    { "Sint Eustatius", "Синт-Эстатиус" },
    { "Saba", "Саба" },
    { "Puerto Rico", "Пуэрто-Рико" },
    { "Dominican Republic", "Доминиканская Республика" },
    { "Haiti", "Гаити" },
    { "Cuba", "Куба" },
    { "Jamaica", "Ямайка" },
    { "Bahamas", "Багамы" },
    { "Guatemala", "Гватемала" },
    { "Belize", "Белиз" },
    { "El Salvador", "Сальвадор" },
    { "Honduras", "Гондурас" },
    { "Nicaragua", "Никарагуа" },
    { "Costa Rica", "Коста-Рика" },
    { "Panama", "Панама" }
};

        public TeamDetailsForm(Teams team)
        {
            InitializeComponent();
            _currentTeam = team;
            labelUserName.Text = UserSession.CurrentUser.FullName;
            labelUserRole.Text = UserSession.CurrentUser.Roles.RoleName;
            pictureProfil.Image?.Dispose();
            pictureProfil.Image = PhotoHelper.LoadUserPhoto(UserSession.CurrentUser.PhotoProfil);

            // По умолчанию показываем команду
            panelPlayers.BringToFront();

            // Подсветка активного таба
            labelTeam.ForeColor = Color.FromArgb(0, 200, 150); // Зелёный
            labelCoach.ForeColor = Color.Gray; // Серый
        }

        /// <summary>
        /// Предзагружает все фото игроков в кэш (опционально)
        /// </summary>
        private async Task PreloadPlayerPhotosAsync()
        {
            foreach (var player in _players)
            {
                if (!string.IsNullOrEmpty(player.Photo))
                {
                    // Загружаем в кэш, но не ждём завершения
                    _ = ImageLoader.LoadToPictureBoxAsync(
                        new PictureBox(), // Временный контрол для кэширования
                        player.Photo,
                        Properties.Resources.player_picture);
                }
            }
        }

        /// <summary>
        /// Загружает данные тренера команды (асинхронно)
        /// </summary>
        private async Task LoadCoachDataAsync()
        {
            if (_currentTeam == null) return;

            // Получаем тренера команды
            _currentCoach = Program.context.Coaches
                .FirstOrDefault(c => c.TeamId == _currentTeam.IdTeam);

            if (_currentCoach == null)
            {
                labelFullNameCoach.Text = "Тренер не назначен";
                labelNationality.Text = "";
                labelAgeCoach.Text = "";
                labelStageWork.Text = "";
              //  lab.Text = "";
                labelDescriptionCoach.Text = "";
                pictureCoach.Image = Properties.Resources.player_picture;
                return;
            }

            // Заполняем данные (текст — мгновенно)
            labelFullNameCoach.Text += _currentCoach.FullName ?? "Не указано";
            labelNationality.Text += TranslateCountry(_currentCoach.Country);
            labelAgeCoach.Text += _currentCoach.Age.HasValue ? $"{_currentCoach.Age} лет" : "Не указан";
            labelStageWork.Text += _currentCoach.Experience.HasValue ? $"{_currentCoach.Experience} лет" : "Не указан";
            labelShceme.Text += _currentCoach.SchemeGame ?? "Не указана";
            labelDescriptionCoach.Text = _currentCoach.Description ?? "Описание отсутствует";

            // Фото — асинхронно
            if (!string.IsNullOrEmpty(_currentCoach.Photo))
            {
                await ImageLoader.LoadToPictureBoxAsync(
                    pictureCoach,
                    _currentCoach.Photo,
                    Properties.Resources.player_picture);
            }
            else
            {
                pictureCoach.Image = Properties.Resources.player_picture;
            }
        }

        /// <summary>
        /// Фон + границы формы
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            UiPainter.DrawGradientBackground(this, e);
        }

        private void btnCloseBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelTeam_Click(object sender, EventArgs e)
        {
            panelPlayers.BringToFront();
            flvPlayers.Visible = true; 
            btnNext.Visible = true;
            btnPrev.Visible = true;

            // Подсветка текста
            labelTeam.ForeColor = Color.FromArgb(0, 200, 150);
            labelCoach.ForeColor = Color.Gray;

            lineCoach.Visible = false;
            linePlayers.Visible = true;
        }

        private async  void labelCoach_Click(object sender, EventArgs e)
        {
            panelCoach.BringToFront();
            flvPlayers.Visible = false;
            btnNext.Visible = false;
            btnPrev.Visible = false;

            // Подсветка текста
            labelTeam.ForeColor = Color.Gray;
            labelCoach.ForeColor = Color.FromArgb(0, 200, 150);

            lineCoach.Visible = true;
            linePlayers.Visible = false;

            // 👇 Загружаем тренера при переключении на вкладку
            await LoadCoachDataAsync();
        }

        private async void TeamDetailsForm_Load(object sender, EventArgs e)
        {
            // 1. Сначала грузим инфо о команде (текст + лого асинхронно)
            await LoadTeamInfoAsync();

            LoadPlayers();
            SetupNavigation();

            //  Предзагрузка фото игроков и тренера в фоне
            _ = PreloadPlayerPhotosAsync();
            _ = LoadCoachDataAsync(); // Загружаем, но не ждём (данные появятся, когда пользователь откроет вкладку)
        }

        private async Task LoadTeamInfoAsync()
        {
            if (_currentTeam == null) return;

            labelTeamName.Text = _currentTeam.TeamName;

            if (!string.IsNullOrEmpty(_currentTeam.Logo))
            {
                await ImageLoader.LoadToPictureBoxAsync(
                    pictureLogoTeam,
                    _currentTeam.Logo,
                    Properties.Resources.picture);
            }
        }

        private void LoadPlayers()
        {
            if (_currentTeam == null) return;

            _players = Program.context.Players
                .Where(p => p.TeamId == _currentTeam.IdTeam)
                .OrderBy(p => p.Number)
                .ToList();

            if (_players.Count == 0)
            {
                MessageBox.Show("В команде нет игроков", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CreatePlayerThumbnails();
            SelectPlayer(0);
        }

        /// <summary>
        /// Создает кликабельные фото игроков в ОДИН РЯД
        /// </summary>
        private void CreatePlayerThumbnails()
        {
            flvPlayers.Controls.Clear();
            _playerThumbnails.Clear();
            _thumbnailContainers.Clear();

            // 👇 НАСТРОЙКИ ДЛЯ ОДНОГО РЯДА
            flvPlayers.FlowDirection = FlowDirection.LeftToRight;
            flvPlayers.WrapContents = false;  // 👈 Запрещаем перенос!
            flvPlayers.AutoScroll = false;     // 👈 Отключаем автоскролл
            flvPlayers.Padding = new Padding(10);

            // Устанавливаем фиксированную высоту для одного ряда
            flvPlayers.Height = 130; // Достаточно для одного ряда

            foreach (var player in _players)
            {
                var thumbnailContainer = new Guna2Panel
                {
                    Width = 90,
                    Height = 110,
                    Margin = new Padding(5),
                    BorderRadius = 10,
                    FillColor = Color.FromArgb(240, 240, 240),
                    Tag = player
                };

                var pictureBox = new Guna2PictureBox
                {
                    Width = 80,
                    Height = 80,
                    Location = new Point(5, 5),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderRadius = 10,
                    Tag = player,
                    // 👇 СРАЗУ ставим заглушку
                    Image = Properties.Resources.player_picture
                };

                // 👇 Запускаем загрузку фото СРАЗУ (не ждем!)
                if (!string.IsNullOrEmpty(player.Photo))
                {
                    // 👇 Просто вызываем существующий асинхронный метод
                    _ = LoadThumbnailAsync(pictureBox, player.Photo);
                }

                // 👇 ТОЛЬКО ИМЯ (без номера)
                var labelInfo = new Label
                {
                    Text = GetShortName(player.FullName),
                    Location = new Point(5, 88),
                    Width = 80,
                    Height = 20,
                    TextAlign = ContentAlignment.TopCenter,
                    Font = new Font("Microsoft Sans Serif", 7),
                    ForeColor = Color.FromArgb(30, 30, 47),
                    AutoSize = false
                };

                thumbnailContainer.Controls.Add(pictureBox);
                thumbnailContainer.Controls.Add(labelInfo);

                thumbnailContainer.Click += (s, e) => OnPlayerThumbnailClick(player);
                pictureBox.Click += (s, e) => OnPlayerThumbnailClick(player);
                labelInfo.Click += (s, e) => OnPlayerThumbnailClick(player);

                flvPlayers.Controls.Add(thumbnailContainer);
                _playerThumbnails.Add(pictureBox);
                _thumbnailContainers.Add(thumbnailContainer);
            }

            // 👇 Устанавливаем общую ширину для всех миниатюр
            int totalWidth = (_players.Count * 100) + 20; // 100 = 90 ширина + 10 margin
            flvPlayers.Width = Math.Min(totalWidth, this.ClientSize.Width - 40);
        }

        private async Task LoadThumbnailAsync(Guna2PictureBox pictureBox, string photoUrl)
        {
            try
            {
                //  Используем существующий метод ImageLoader
                await ImageLoader.LoadToPictureBoxAsync(
                    pictureBox,
                    photoUrl,
                    Properties.Resources.player_picture);
            }
            catch
            {
                // В случае ошибки оставляем заглушку
                pictureBox.Image = Properties.Resources.player_picture;
            }
        }

        private void OnPlayerThumbnailClick(Players player)
        {
            int index = _players.IndexOf(player);
            if (index >= 0) SelectPlayer(index);
        }

        private void SelectPlayer(int index)
        {
            if (index < 0 || index >= _players.Count) return;

            _selectedIndex = index;
            var player = _players[index];

            UpdateSelectionVisual();
            _ = FillPlayerDataAsync(player);
            UpdateNavigationButtons();
        }

        private void UpdateSelectionVisual()
        {
            for (int i = 0; i < _thumbnailContainers.Count; i++)
            {
                var container = _thumbnailContainers[i];

                if (i == _selectedIndex)
                {
                    container.FillColor = Color.FromArgb(20, 184, 134);
                    container.BorderColor = Color.FromArgb(0, 150, 100);
                    container.BorderThickness = 2;
                }
                else
                {
                    container.FillColor = Color.FromArgb(240, 240, 240);
                    container.BorderColor = Color.Transparent;
                    container.BorderThickness = 0;
                }
            }
        }

        private async Task FillPlayerDataAsync(Players player)
        {
            // Текст — мгновенно
            labelPlayerName.Text = player.FullName ?? "Имя не указано";
            labelNumberPlayer.Text = player.Number.ToString();

            // 👇 Переводим позицию
            labelPosition.Text = TranslatePosition(player.Position);

            // 👇 Переводим страну
            labelNationality.Text = TranslateCountry(player.Country);

            labelAge.Text = player.Age.HasValue ? player.Age.Value.ToString() : "Не указан";
            labelHeight.Text = player.Height.HasValue ? $"{player.Height} см" : "Не указан";
            labelWorkLeg.Text = player.WorkingLeg ?? "Не указана";
            labelYellowCards.Text = player.YellowCard.HasValue ? player.YellowCard.Value.ToString() : "0";
            labelRedCards.Text = player.RedCard.HasValue ? player.RedCard.Value.ToString() : "0";
            labelDescription.Text = player.Description ?? "Описание отсутствует";
            pictureCaptain.Visible = player.IsCaptain == true;

            // Картинка — асинхронно
            if (!string.IsNullOrEmpty(player.Photo))
            {
                await ImageLoader.LoadToPictureBoxAsync(
                    picturePlayer,
                    player.Photo,
                    Properties.Resources.player_picture);
            }
            else
            {
                picturePlayer.Image = Properties.Resources.player_picture;
            }
        }

        /// <summary>
        /// Переводит позицию на русский
        /// </summary>
        private string TranslatePosition(string position)
        {
            if (string.IsNullOrEmpty(position)) return "Не указана";

            if (_positionTranslations.TryGetValue(position, out string translated))
            {
                return translated;
            }

            return position;
        }

        /// <summary>
        /// Переводит страну на русский
        /// </summary>
        private string TranslateCountry(string country)
        {
            if (string.IsNullOrEmpty(country)) return "Не указана";

            if (_countryTranslations.TryGetValue(country, out string translated))
            {
                return translated;
            }

            return country;
        }

        private string GetShortName(string fullName)
        {
            if (string.IsNullOrEmpty(fullName)) return "";
            var parts = fullName.Split(' ');
            if (parts.Length >= 2) return $"{parts[0]}\n{parts[1].FirstOrDefault()}.";
            return fullName.Length > 10 ? fullName.Substring(0, 10) + "..." : fullName;
        }

        private void SetupNavigation()
        {
            btnPrev.Enabled = false;
            btnNext.Enabled = _players.Count > 1;
        }


        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_selectedIndex > 0)
            {
                SelectPlayer(_selectedIndex - 1);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_selectedIndex < _players.Count - 1)
            {
                SelectPlayer(_selectedIndex + 1);
            }
        }

        /// <summary>
        /// Обновляет состояние кнопок навигации (ЕДИНСТВЕННЫЙ экземпляр)
        /// </summary>
        private void UpdateNavigationButtons()
        {
            btnPrev.Enabled = _selectedIndex > 0;
            btnNext.Enabled = _selectedIndex < _players.Count - 1;

            // Прокрутка к выбранному игроку (только стрелками)
            if (_selectedIndex >= 0 && _selectedIndex < _thumbnailContainers.Count)
            {
                var selectedControl = _thumbnailContainers[_selectedIndex];

                // Вычисляем позицию для прокрутки
                int targetPosition = selectedControl.Left - (flvPlayers.Width / 2) + (selectedControl.Width / 2);

                // Плавная прокрутка (опционально)
                flvPlayers.ScrollControlIntoView(selectedControl);
            }
        }
    }
}
