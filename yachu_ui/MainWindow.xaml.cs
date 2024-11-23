using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Windows;
using System.Windows.Controls;

namespace yachu_ui
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Jokbo.rr_btn_list.Clear();
        }
        private void roll_btn_Click(object sender, RoutedEventArgs e) //roll 버튼 누를 시 action
        {
            
            if (!Jokbo.Un_list.Contains(1)) ones.IsEnabled = true; //ones~yacht 버튼 활성화
            if (!Jokbo.Un_list.Contains(2)) Twos.IsEnabled = true;
            if (!Jokbo.Un_list.Contains(3)) Threes.IsEnabled = true;
            if (!Jokbo.Un_list.Contains(4)) Fours.IsEnabled = true;
            if (!Jokbo.Un_list.Contains(5)) Fives.IsEnabled = true;
            if (!Jokbo.Un_list.Contains(6)) Sixes.IsEnabled = true;
            if (!Jokbo.Un_list.Contains(7)) Choice.IsEnabled = true;
            if (!Jokbo.Un_list.Contains(8)) Four_of_a_kind.IsEnabled = true;
            if (!Jokbo.Un_list.Contains(9)) Full_House.IsEnabled = true;
            if (!Jokbo.Un_list.Contains(10)) Little_Straight.IsEnabled = true;
            if (!Jokbo.Un_list.Contains(11)) Big_Straight.IsEnabled = true;
            if (!Jokbo.Un_list.Contains(12)) Yacht.IsEnabled = true;

            d1.IsEnabled = true;
            d2.IsEnabled = true;
            d3.IsEnabled = true;
            d4.IsEnabled = true;
            d5.IsEnabled = true;

            

            Random rnd = new Random();

            if (Jokbo.reroll_btn_level == 0 || Jokbo.remain_chance == 0) //주사위 돌리기
            {
                
                //주사위를 5번 굴리고 Jokbo.roll_list에 저장
                for (int i = 0; i < 5; i++) Jokbo.roll_list.Add(rnd.Next(1, 7));

                for (int i = 0; i < 5; i++) //주사위를 순서대로 나열
                {
                    for (int j = i + 1; j < 5; j++)
                    {
                        if (Jokbo.roll_list[i] > Jokbo.roll_list[j])
                        {
                            int tmp;
                            tmp = Jokbo.roll_list[j];
                            Jokbo.roll_list[j] = Jokbo.roll_list[i];
                            Jokbo.roll_list[i] = tmp;
                        }
                    }
                }
               
                //각 주사위에 roll리스트 값 입력
                d1.Content = Jokbo.roll_list[0];
                d2.Content = Jokbo.roll_list[1];
                d3.Content = Jokbo.roll_list[2];
                d4.Content = Jokbo.roll_list[3];
                d5.Content = Jokbo.roll_list[4];


                if (!Jokbo.Un_list.Contains(1)) ones.IsEnabled = true; //ones~yacht 버튼 활성화
                if (!Jokbo.Un_list.Contains(2)) Twos.IsEnabled = true;
                if (!Jokbo.Un_list.Contains(3)) Threes.IsEnabled = true;
                if (!Jokbo.Un_list.Contains(4)) Fours.IsEnabled = true;
                if (!Jokbo.Un_list.Contains(5)) Fives.IsEnabled = true;
                if (!Jokbo.Un_list.Contains(6)) Sixes.IsEnabled = true;
                if (!Jokbo.Un_list.Contains(7)) Choice.IsEnabled = true;
                if (!Jokbo.Un_list.Contains(8)) Four_of_a_kind.IsEnabled = true;
                if (!Jokbo.Un_list.Contains(9)) Full_House.IsEnabled = true;
                if (!Jokbo.Un_list.Contains(10)) Little_Straight.IsEnabled = true;
                if (!Jokbo.Un_list.Contains(11)) Big_Straight.IsEnabled = true;
                if (!Jokbo.Un_list.Contains(12)) Yacht.IsEnabled = true;

                roll_btn.IsEnabled = false; //roll 버튼 비활성화
                Jokbo.remain_chance = 2;
                Jokbo.rr_btn_list.Clear();
            }
            else if(Jokbo.reroll_btn_level > 0 && Jokbo.remain_chance > 0) //주사위 다시 돌리기
            {
                if (!Jokbo.Un_list.Contains(1)) ones.IsEnabled = true; //ones~yacht 버튼 활성화
                if (!Jokbo.Un_list.Contains(2)) Twos.IsEnabled = true;
                if (!Jokbo.Un_list.Contains(3)) Threes.IsEnabled = true;
                if (!Jokbo.Un_list.Contains(4)) Fours.IsEnabled = true;
                if (!Jokbo.Un_list.Contains(5)) Fives.IsEnabled = true;
                if (!Jokbo.Un_list.Contains(6)) Sixes.IsEnabled = true;
                if (!Jokbo.Un_list.Contains(7)) Choice.IsEnabled = true;
                if (!Jokbo.Un_list.Contains(8)) Four_of_a_kind.IsEnabled = true;
                if (!Jokbo.Un_list.Contains(9)) Full_House.IsEnabled = true;
                if (!Jokbo.Un_list.Contains(10)) Little_Straight.IsEnabled = true;
                if (!Jokbo.Un_list.Contains(11)) Big_Straight.IsEnabled = true;
                if (!Jokbo.Un_list.Contains(12)) Yacht.IsEnabled = true;

                if (Jokbo.reroll_btn_level >= 1)
                {
                    int tmp1 = Jokbo.rr_btn_list[0] - 1;
                    Jokbo.roll_list[tmp1] = rnd.Next(1, 7);
                                       
                    if (Jokbo.reroll_btn_level == 2)
                    {
                        int tmp2 = Jokbo.rr_btn_list[1] - 1;
                        Jokbo.roll_list[tmp2] = rnd.Next(1, 7);
                    }

                    for (int i = 0; i < 5; i++) //주사위를 순서대로 나열
                    {
                        for (int j = i + 1; j < 5; j++)
                        {
                            if (Jokbo.roll_list[i] > Jokbo.roll_list[j])
                            {
                                int tmp;
                                tmp = Jokbo.roll_list[j];
                                Jokbo.roll_list[j] = Jokbo.roll_list[i];
                                Jokbo.roll_list[i] = tmp;
                            }
                        }
                    }

                    d1.Content = Jokbo.roll_list[0];
                    d2.Content = Jokbo.roll_list[1];
                    d3.Content = Jokbo.roll_list[2];
                    d4.Content = Jokbo.roll_list[3];
                    d5.Content = Jokbo.roll_list[4];

                    d1.Opacity = 1;
                    d2.Opacity = 1;
                    d3.Opacity = 1;
                    d4.Opacity = 1;
                    d5.Opacity = 1;
                }
               Jokbo.rr_btn_list.Clear();
               Jokbo.reroll_btn_level = 0;
               Jokbo.remain_chance--;
                if (Jokbo.remain_chance == 0)
                {
                    d1.IsEnabled = false;
                    d2.IsEnabled = false;
                    d3.IsEnabled = false;
                    d4.IsEnabled = false;
                    d5.IsEnabled = false;

                    roll_btn.IsEnabled = false;
                }
                reroll_cnt.Content = $"다시 돌리기 : {Jokbo.remain_chance}";
            }
        }
        class Scoring
        {
            public void score() //점수 내는 클래스
            {
                int score_cnt = 12 - Jokbo.roll_btn_cnt;
                int Jokbo_factor = Jokbo.jokbo_list[score_cnt * 6 + 5];
                int[] score_Jokbo = new int[5];
                for (int i = 0; i < 5; i++) score_Jokbo[i] = Jokbo.jokbo_list[score_cnt * 6 + i];
                int temp_score = 0;

                if (Jokbo_factor >= 1 && Jokbo_factor <= 6) //factor가 1~6 사이일때 지역 배열 score_jokbo에서 factor와 동등값 확인 후 임시스코어 변환
                {
                    for (int i = 0; i < 5; i++) { if (score_Jokbo[i] == Jokbo_factor) temp_score += Jokbo_factor; }
                }
                else if (Jokbo_factor == 7) for (int i = 0; i < 5; i++) temp_score += score_Jokbo[i]; //배열의 모든 합
                else if (Jokbo_factor == 8) //배열 내 값이 4개 이상 같으면 배열의 모든 합을 더한다 오류
                {
                    int a = score_Jokbo[0];
                    int b = score_Jokbo[1];
                    int c = score_Jokbo[2];
                    int d = score_Jokbo[3];
                    int e = score_Jokbo[4];
                    if (a == b && b == c && c == d) for (int k = 0; k < 5; k++) temp_score += score_Jokbo[k];
                    else if (b == c && c == d && d == e) for (int k = 0; k < 5; k++) temp_score += score_Jokbo[k];
                }
                else if (Jokbo_factor == 9) //주사위를 2개,3개씩으로 묶었을때 각각의 묶음 안에서 주사위 값이 같은 경우
                {
                    int dup; //dup 배열 내 중복 개수
                    int a = score_Jokbo[0];
                    int b = score_Jokbo[1];
                    int c = score_Jokbo[2];
                    int d = score_Jokbo[3];
                    int e = score_Jokbo[4];
                    for (int i = 0; i < 5; i++)
                    {
                        dup = 0;
                        for (int j = 0; j < 5; j++)
                        {
                            if (score_Jokbo[i] == score_Jokbo[j] && i != j) dup++;
                        }

                        if ((dup == 2 && a == c && d == e)) { for (int k = 0; k < 5; k++) temp_score += score_Jokbo[k]; break; }
                        else if ((dup == 2 && c == e && a == b)) { for (int k = 0; k < 5; k++) temp_score += score_Jokbo[k]; break; }
                    }
                }
                else if (Jokbo_factor == 10) //이어지는 숫자가 4개 이상
                {
                    if (score_Jokbo[0] == 1 && score_Jokbo[1] == 2 && score_Jokbo[2] == 3 && score_Jokbo[3] == 4) temp_score = 15;
                    else if (score_Jokbo[1] == 2 && score_Jokbo[2] == 3 && score_Jokbo[3] == 4 && score_Jokbo[4] == 5) temp_score = 15;
                    else if (score_Jokbo[0] == 2 && score_Jokbo[1] == 3 && score_Jokbo[2] == 4 && score_Jokbo[3] == 5) temp_score = 15;
                    else if (score_Jokbo[1] == 3 && score_Jokbo[2] == 4 && score_Jokbo[3] == 5 && score_Jokbo[4] == 6) temp_score = 15;
                    else if (score_Jokbo[0] == 3 && score_Jokbo[1] == 4 && score_Jokbo[2] == 5 && score_Jokbo[3] == 6) temp_score = 15;
                }
                else if (Jokbo_factor == 11) // 이어지는 숫자가 5개
                {
                    if (score_Jokbo[0] == 1 && score_Jokbo[1] == 2 && score_Jokbo[2] == 3 && score_Jokbo[3] == 4 && score_Jokbo[4] == 5) temp_score = 30;
                    else if (score_Jokbo[0] == 2 && score_Jokbo[1] == 3 && score_Jokbo[2] == 4 && score_Jokbo[3] == 5 && score_Jokbo[4] == 6) temp_score = 30;
                }
                else if (Jokbo_factor == 12) //5개가 모두 동일한 숫자
                {
                    int dup; //dup 배열 내 중복 개수
                    for (int i = 0; i < 5; i++)
                    {
                        dup = 0;
                        for (int j = 0; j < 5; j++)
                        {
                            if (score_Jokbo[i] == score_Jokbo[j] && i != j) dup++;
                            if (dup == 4) { temp_score = 50; break; }
                        }
                    }
                }
                Jokbo.total_score += temp_score;

            }
        }
        static class Jokbo
        {
            public static List<int> jokbo_list = new List<int>();
            public static List<int> roll_list = new List<int>();

            public static string jokbo_type;

            public static List<int> Un_list = new List<int>(); //one버튼 컨트롤

            public static int roll_btn_cnt = 12; //게임 진행도
            public static int total_score = 0;//최종점수 합산

            public static int reroll_btn_level = 0; //reroll 버튼 레벨 변수
            public static List<int> rr_btn_list = new List<int>();
            public static int remain_chance = 2;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            d1.IsEnabled = false;
            d2.IsEnabled = false;
            d3.IsEnabled = false;
            d4.IsEnabled = false;
            d5.IsEnabled = false;
            
            Button btn = sender as Button;
            Jokbo.jokbo_type = btn.Name;

            roll_btn.Content = "주사위 굴리기!";

            if (Jokbo.roll_btn_cnt == 0)
            {
                score.Content = "Score : " + Jokbo.total_score.ToString();

                roll_btn.IsEnabled = false;  //roll버튼을 12회 클릭시 비활성화
                ones.IsEnabled = false; //one ~ yacht 버튼 비활성화
                Twos.IsEnabled = false;
                Threes.IsEnabled = false;
                Fours.IsEnabled = false;
                Fives.IsEnabled = false;
                Sixes.IsEnabled = false;
                Choice.IsEnabled = false;
                Four_of_a_kind.IsEnabled = false;
                Full_House.IsEnabled = false;
                Little_Straight.IsEnabled = false;
                Big_Straight.IsEnabled = false;
                Yacht.IsEnabled = false;

                roll_btn.Content = "점수 내기";
            }
            string tmp_roll = "";
            for (int i = 0; i < 5; i++) tmp_roll += Jokbo.roll_list[i];
            
            for (int i = 0; i < 5; i++)
            {
                Jokbo.jokbo_list.Add(Jokbo.roll_list[i]);
            }
            
            switch (Jokbo.jokbo_type)
            {
                case "ones": Ones_indi.Content = tmp_roll; Jokbo.Un_list.Add(1); Jokbo.jokbo_list.Add(1); break;
                case "Twos": Two_indi.Content = tmp_roll; Jokbo.Un_list.Add(2); Jokbo.jokbo_list.Add(2); break;
                case "Threes": Threes_indi.Content = tmp_roll; Jokbo.Un_list.Add(3); Jokbo.jokbo_list.Add(3); break;
                case "Fours": Fours_indi.Content = tmp_roll; Jokbo.Un_list.Add(4); Jokbo.jokbo_list.Add(4); break;
                case "Fives": Fives_indi.Content = tmp_roll; Jokbo.Un_list.Add(5); Jokbo.jokbo_list.Add(5); break;
                case "Sixes": Sixes_indi.Content = tmp_roll; Jokbo.Un_list.Add(6); Jokbo.jokbo_list.Add(6); break;
                case "Choice": Choice_indi.Content = tmp_roll; Jokbo.Un_list.Add(7); Jokbo.jokbo_list.Add(7); break;
                case "Four_of_a_kind": Four_of_a_kind_indi.Content = tmp_roll; Jokbo.Un_list.Add(8); Jokbo.jokbo_list.Add(8); break;
                case "Full_House": FullHouse_indi.Content = tmp_roll; Jokbo.Un_list.Add(9); Jokbo.jokbo_list.Add(9); break;
                case "Little_Straight": Little_straight_indi.Content = tmp_roll; Jokbo.Un_list.Add(10); Jokbo.jokbo_list.Add(10); break;
                case "Big_Straight": Big_straight_indi.Content = tmp_roll; Jokbo.Un_list.Add(11); Jokbo.jokbo_list.Add(11); break;
                case "Yacht": Yacht_indi.Content = tmp_roll; Jokbo.Un_list.Add(12); Jokbo.jokbo_list.Add(12); break;
            }

            Scoring scoring = new Scoring(); //scoring 함수 호출 및 초기화
            scoring.score(); //scoring 함수 사용

            score.Content = "score : " + Jokbo.total_score.ToString();
            Jokbo.roll_list.Clear();

            roll_btn.IsEnabled = false;
            ones.IsEnabled = false; // one~ yacht 버튼 클릭 후 버튼 비활성화
            Twos.IsEnabled = false;
            Threes.IsEnabled = false;
            Fours.IsEnabled = false;
            Fives.IsEnabled = false;
            Sixes.IsEnabled = false;
            Choice.IsEnabled = false;
            Four_of_a_kind.IsEnabled = false;
            Full_House.IsEnabled = false;
            Little_Straight.IsEnabled = false;
            Big_Straight.IsEnabled = false;
            Yacht.IsEnabled = false;

            
            Jokbo.roll_btn_cnt--;
            cur_status.Content = $"현재 진행도 {12 - Jokbo.roll_btn_cnt} / 12";

            roll_btn.IsEnabled = true; //roll 버튼 비활성화
            if (12 - Jokbo.roll_btn_cnt == 0)
            {
                d1.IsEnabled = false;
                d2.IsEnabled = false;
                d3.IsEnabled = false;
                d4.IsEnabled = false;
                d5.IsEnabled = false;

                roll_btn.IsEnabled = false;

                ones.IsEnabled = false; //one ~ yacht 버튼 비활성화
                Twos.IsEnabled = false;
                Threes.IsEnabled = false;
                Fours.IsEnabled = false;
                Fives.IsEnabled = false;
                Sixes.IsEnabled = false;
                Choice.IsEnabled = false;
                Four_of_a_kind.IsEnabled = false;
                Full_House.IsEnabled = false;
                Little_Straight.IsEnabled = false;
                Big_Straight.IsEnabled = false;
                Yacht.IsEnabled = false;
            }

            Jokbo.remain_chance = 2;
            reroll_cnt.Content = $"다시 돌리기 : {Jokbo.remain_chance}";
        }

        private void d1_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string dice_name = btn.Name;
            

            int rr_btn_cnt;
            rr_btn_cnt = Jokbo.rr_btn_list.Count;

            if (dice_name == "d1" && !Jokbo.rr_btn_list.Contains(1) && rr_btn_cnt < 2) { Jokbo.rr_btn_list.Add(1);   Jokbo.reroll_btn_level++; }
            else if (dice_name == "d1" && Jokbo.rr_btn_list.Contains(1) && rr_btn_cnt > 0) { Jokbo.rr_btn_list.Remove(1); Jokbo.reroll_btn_level--; }
            if (dice_name == "d2" && !Jokbo.rr_btn_list.Contains(2) && rr_btn_cnt < 2) { Jokbo.rr_btn_list.Add(2);   Jokbo.reroll_btn_level++; }
            else if (dice_name == "d2" && Jokbo.rr_btn_list.Contains(2) && rr_btn_cnt > 0) { Jokbo.rr_btn_list.Remove(2); Jokbo.reroll_btn_level--; }
            if (dice_name == "d3" && !Jokbo.rr_btn_list.Contains(3) && rr_btn_cnt < 2) { Jokbo.rr_btn_list.Add(3);   Jokbo.reroll_btn_level++; }
            else if (dice_name == "d3" && Jokbo.rr_btn_list.Contains(3) && rr_btn_cnt > 0) { Jokbo.rr_btn_list.Remove(3); Jokbo.reroll_btn_level--; }
            if (dice_name == "d4" && !Jokbo.rr_btn_list.Contains(4) && rr_btn_cnt < 2) { Jokbo.rr_btn_list.Add(4);   Jokbo.reroll_btn_level++; }
            else if (dice_name == "d4" && Jokbo.rr_btn_list.Contains(4) && rr_btn_cnt > 0) { Jokbo.rr_btn_list.Remove(4); Jokbo.reroll_btn_level--; }
            if (dice_name == "d5" && !Jokbo.rr_btn_list.Contains(5) && rr_btn_cnt < 2) { Jokbo.rr_btn_list.Add(5);   Jokbo.reroll_btn_level++; }
            else if (dice_name == "d5" && Jokbo.rr_btn_list.Contains(5) && rr_btn_cnt > 0) { Jokbo.rr_btn_list.Remove(5); Jokbo.reroll_btn_level--; }                                           
       
            rr_btn_cnt = Jokbo.rr_btn_list.Count;

            if (rr_btn_cnt > 0) { roll_btn.IsEnabled = true; roll_btn.Content = "다시 돌리기!"; }
            else { roll_btn.IsEnabled = false;}

            if(rr_btn_cnt == 0) //wpf xml 문법이 너무 어려워서 하드코딩으로 처리
            {
                if (!Jokbo.Un_list.Contains(1)) ones.IsEnabled = true; //ones~yacht 버튼 활성화
                if (!Jokbo.Un_list.Contains(2)) Twos.IsEnabled = true;
                if (!Jokbo.Un_list.Contains(3)) Threes.IsEnabled = true;
                if (!Jokbo.Un_list.Contains(4)) Fours.IsEnabled = true;
                if (!Jokbo.Un_list.Contains(5)) Fives.IsEnabled = true;
                if (!Jokbo.Un_list.Contains(6)) Sixes.IsEnabled = true;
                if (!Jokbo.Un_list.Contains(7)) Choice.IsEnabled = true;
                if (!Jokbo.Un_list.Contains(8)) Four_of_a_kind.IsEnabled = true;
                if (!Jokbo.Un_list.Contains(9)) Full_House.IsEnabled = true;
                if (!Jokbo.Un_list.Contains(10)) Little_Straight.IsEnabled = true;
                if (!Jokbo.Un_list.Contains(11)) Big_Straight.IsEnabled = true;
                if (!Jokbo.Un_list.Contains(12)) Yacht.IsEnabled = true;
            }


            if (!Jokbo.rr_btn_list.Contains(1) && rr_btn_cnt == 2) d1.IsEnabled = false; //리롤 버튼을 두 개 이상 눌렀을때 나머지를 비활성화
            if (!Jokbo.rr_btn_list.Contains(2) && rr_btn_cnt == 2) d2.IsEnabled = false;
            if (!Jokbo.rr_btn_list.Contains(3) && rr_btn_cnt == 2) d3.IsEnabled = false;
            if (!Jokbo.rr_btn_list.Contains(4) && rr_btn_cnt == 2) d4.IsEnabled = false;
            if (!Jokbo.rr_btn_list.Contains(5) && rr_btn_cnt == 2) d5.IsEnabled = false;

            if(rr_btn_cnt == 1) { d1.IsEnabled = true; d2.IsEnabled = true; d3.IsEnabled = true; d4.IsEnabled = true; d5.IsEnabled = true; }

            if(Jokbo.rr_btn_list.Contains(1)) d1.Opacity = 1; //리롤 버튼을 처음으로 눌렀을때 투명도를 0으로
            if (Jokbo.rr_btn_list.Contains(2)) d2.Opacity = 1;
            if (Jokbo.rr_btn_list.Contains(3)) d3.Opacity = 1;
            if (Jokbo.rr_btn_list.Contains(4)) d4.Opacity = 1;
            if (Jokbo.rr_btn_list.Contains(5)) d5.Opacity = 1;
            
            if (!Jokbo.rr_btn_list.Contains(1)) d1.Opacity = 0.5; //리롤 버튼을 두 번 눌렀을때 투명도를 0.5로
            if (!Jokbo.rr_btn_list.Contains(2)) d2.Opacity = 0.5;
            if (!Jokbo.rr_btn_list.Contains(3)) d3.Opacity = 0.5;
            if (!Jokbo.rr_btn_list.Contains(4)) d4.Opacity = 0.5;
            if (!Jokbo.rr_btn_list.Contains(5)) d5.Opacity = 0.5;

            if(rr_btn_cnt != 0)
            {
            ones.IsEnabled = false; // one~ yacht 버튼 클릭 후 버튼 비활성화
            Twos.IsEnabled = false;
            Threes.IsEnabled = false;
            Fours.IsEnabled = false;
            Fives.IsEnabled = false;
            Sixes.IsEnabled = false;
            Choice.IsEnabled = false;
            Four_of_a_kind.IsEnabled = false;
            Full_House.IsEnabled = false;
            Little_Straight.IsEnabled = false;
            Big_Straight.IsEnabled = false;
            Yacht.IsEnabled = false;
            }
        }
    }
}

