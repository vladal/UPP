﻿
using System;
using System.Data.SqlClient;
using V82;
using V82.ДокументыСсылка;
using V82.Документы;//Менеджер;
using V82.ДокументыСсылка;
using V82.Перечисления;//Ссылка;
namespace V82.Документы//Менеджер
{
	///<summary>
	///(Регл)
	///</summary>
	public partial class ЗарплатаКВыплатеОрганизаций:ДокументМенеджер
	{
		
		public static ДокументыСсылка.ЗарплатаКВыплатеОрганизаций НайтиПоСсылке(Guid _Ссылка)
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = @"Select top 1 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_Fld4683RRef [Организация]
					,_Fld4684 [ПериодРегистрации]
					,_Fld4685RRef [СпособВыплаты]
					,_Fld4686RRef [Ответственный]
					,_Fld4687 [Комментарий]
					,_Fld4688 [ДнейНеВыплаты]
					,_Fld4689 [КраткийСоставДокумента]
					,_Fld4690RRef [ХарактерВыплаты]
					,_Fld4691RRef [ПодразделениеОрганизации]
					,_Fld4692_TYPE [ДокументОснование_Тип],_Fld4692_RRRef [ДокументОснование],_Fld4692_RTRef [ДокументОснование_Вид]
					,_Fld4693 [ДатаНачала]
					,_Fld4694 [ДатаОкончания]
					,_Fld21437RRef [Банк]
					,_Fld26732 [ПроцентВыплаты]
					,_Fld26733 [ПредварительныйУчетУдержаний]
					,_Fld26734RRef [Округление]
					,_Fld26735 [СуммаДокумента]
					,_Fld26736 [ДанныеПрошлойВерсии]
					From _Document268(NOLOCK)
					Where _IDRRef=@Ссылка";
					Команда.Parameters.AddWithValue("Ссылка", _Ссылка);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ЗарплатаКВыплатеОрганизаций();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(4);
							Ссылка.СпособВыплаты = V82.Перечисления/*Ссылка*/.СпособыВыплатыЗарплаты.ПустаяСсылка.Получить((byte[])Читалка.GetValue(5));
							Ссылка.Комментарий = Читалка.GetString(7);
							Ссылка.ДнейНеВыплаты = Читалка.GetDecimal(8);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(9);
							Ссылка.ХарактерВыплаты = V82.Перечисления/*Ссылка*/.ХарактерВыплатыЗарплаты.ПустаяСсылка.Получить((byte[])Читалка.GetValue(10));
							Ссылка.ДатаНачала = Читалка.GetDateTime(15);
							Ссылка.ДатаОкончания = Читалка.GetDateTime(16);
							Ссылка.ПроцентВыплаты = Читалка.GetDecimal(18);
							Ссылка.ПредварительныйУчетУдержаний = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.Округление = V82.Перечисления/*Ссылка*/.СпособыОкругленияЗарплатыКВыплате.ПустаяСсылка.Получить((byte[])Читалка.GetValue(20));
							Ссылка.СуммаДокумента = Читалка.GetDecimal(21);
							Ссылка.ДанныеПрошлойВерсии = ((byte[])Читалка.GetValue(22))[0]==1;
							return Ссылка;
						}
						else
						{
							return null;
						}
					}
				}
			}
		}
		
		public static ДокументыСсылка.ЗарплатаКВыплатеОрганизаций НайтиПоНомеру(string Номер)
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = @"Select top 1 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_Fld4683RRef [Организация]
					,_Fld4684 [ПериодРегистрации]
					,_Fld4685RRef [СпособВыплаты]
					,_Fld4686RRef [Ответственный]
					,_Fld4687 [Комментарий]
					,_Fld4688 [ДнейНеВыплаты]
					,_Fld4689 [КраткийСоставДокумента]
					,_Fld4690RRef [ХарактерВыплаты]
					,_Fld4691RRef [ПодразделениеОрганизации]
					,_Fld4692_TYPE [ДокументОснование_Тип],_Fld4692_RRRef [ДокументОснование],_Fld4692_RTRef [ДокументОснование_Вид]
					,_Fld4693 [ДатаНачала]
					,_Fld4694 [ДатаОкончания]
					,_Fld21437RRef [Банк]
					,_Fld26732 [ПроцентВыплаты]
					,_Fld26733 [ПредварительныйУчетУдержаний]
					,_Fld26734RRef [Округление]
					,_Fld26735 [СуммаДокумента]
					,_Fld26736 [ДанныеПрошлойВерсии]
					From _Document268(NOLOCK)
					Where _Number = @Номер";
					Команда.Parameters.AddWithValue("Номер", Номер);
					using (var Читалка = Команда.ExecuteReader())
					{
						if (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ЗарплатаКВыплатеОрганизаций();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(4);
							Ссылка.СпособВыплаты = V82.Перечисления/*Ссылка*/.СпособыВыплатыЗарплаты.ПустаяСсылка.Получить((byte[])Читалка.GetValue(5));
							Ссылка.Комментарий = Читалка.GetString(7);
							Ссылка.ДнейНеВыплаты = Читалка.GetDecimal(8);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(9);
							Ссылка.ХарактерВыплаты = V82.Перечисления/*Ссылка*/.ХарактерВыплатыЗарплаты.ПустаяСсылка.Получить((byte[])Читалка.GetValue(10));
							Ссылка.ДатаНачала = Читалка.GetDateTime(15);
							Ссылка.ДатаОкончания = Читалка.GetDateTime(16);
							Ссылка.ПроцентВыплаты = Читалка.GetDecimal(18);
							Ссылка.ПредварительныйУчетУдержаний = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.Округление = V82.Перечисления/*Ссылка*/.СпособыОкругленияЗарплатыКВыплате.ПустаяСсылка.Получить((byte[])Читалка.GetValue(20));
							Ссылка.СуммаДокумента = Читалка.GetDecimal(21);
							Ссылка.ДанныеПрошлойВерсии = ((byte[])Читалка.GetValue(22))[0]==1;
							return Ссылка;
						}
						else
						{
							return null;
						}
					}
				}
			}
		}
		
		public static ДокументыВыборка.ЗарплатаКВыплатеОрганизаций Выбрать()
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = @"Select top 1000 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_Fld4683RRef [Организация]
					,_Fld4684 [ПериодРегистрации]
					,_Fld4685RRef [СпособВыплаты]
					,_Fld4686RRef [Ответственный]
					,_Fld4687 [Комментарий]
					,_Fld4688 [ДнейНеВыплаты]
					,_Fld4689 [КраткийСоставДокумента]
					,_Fld4690RRef [ХарактерВыплаты]
					,_Fld4691RRef [ПодразделениеОрганизации]
					,_Fld4692_TYPE [ДокументОснование_Тип],_Fld4692_RRRef [ДокументОснование],_Fld4692_RTRef [ДокументОснование_Вид]
					,_Fld4693 [ДатаНачала]
					,_Fld4694 [ДатаОкончания]
					,_Fld21437RRef [Банк]
					,_Fld26732 [ПроцентВыплаты]
					,_Fld26733 [ПредварительныйУчетУдержаний]
					,_Fld26734RRef [Округление]
					,_Fld26735 [СуммаДокумента]
					,_Fld26736 [ДанныеПрошлойВерсии]
					From _Document268(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.ЗарплатаКВыплатеОрганизаций();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ЗарплатаКВыплатеОрганизаций();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(4);
							Ссылка.СпособВыплаты = V82.Перечисления/*Ссылка*/.СпособыВыплатыЗарплаты.ПустаяСсылка.Получить((byte[])Читалка.GetValue(5));
							Ссылка.Комментарий = Читалка.GetString(7);
							Ссылка.ДнейНеВыплаты = Читалка.GetDecimal(8);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(9);
							Ссылка.ХарактерВыплаты = V82.Перечисления/*Ссылка*/.ХарактерВыплатыЗарплаты.ПустаяСсылка.Получить((byte[])Читалка.GetValue(10));
							Ссылка.ДатаНачала = Читалка.GetDateTime(15);
							Ссылка.ДатаОкончания = Читалка.GetDateTime(16);
							Ссылка.ПроцентВыплаты = Читалка.GetDecimal(18);
							Ссылка.ПредварительныйУчетУдержаний = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.Округление = V82.Перечисления/*Ссылка*/.СпособыОкругленияЗарплатыКВыплате.ПустаяСсылка.Получить((byte[])Читалка.GetValue(20));
							Ссылка.СуммаДокумента = Читалка.GetDecimal(21);
							Ссылка.ДанныеПрошлойВерсии = ((byte[])Читалка.GetValue(22))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.ЗарплатаКВыплатеОрганизаций ВыбратьПоСсылке(int Первые,Guid Мин,Guid Макс)
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = string.Format(@"Select top {0} 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_Fld4683RRef [Организация]
					,_Fld4684 [ПериодРегистрации]
					,_Fld4685RRef [СпособВыплаты]
					,_Fld4686RRef [Ответственный]
					,_Fld4687 [Комментарий]
					,_Fld4688 [ДнейНеВыплаты]
					,_Fld4689 [КраткийСоставДокумента]
					,_Fld4690RRef [ХарактерВыплаты]
					,_Fld4691RRef [ПодразделениеОрганизации]
					,_Fld4692_TYPE [ДокументОснование_Тип],_Fld4692_RRRef [ДокументОснование],_Fld4692_RTRef [ДокументОснование_Вид]
					,_Fld4693 [ДатаНачала]
					,_Fld4694 [ДатаОкончания]
					,_Fld21437RRef [Банк]
					,_Fld26732 [ПроцентВыплаты]
					,_Fld26733 [ПредварительныйУчетУдержаний]
					,_Fld26734RRef [Округление]
					,_Fld26735 [СуммаДокумента]
					,_Fld26736 [ДанныеПрошлойВерсии]
					From _Document268(NOLOCK)
					Where _IDRRef between @Мин and @Макс
					Order by _IDRRef", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.ЗарплатаКВыплатеОрганизаций();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ЗарплатаКВыплатеОрганизаций();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(4);
							Ссылка.СпособВыплаты = V82.Перечисления/*Ссылка*/.СпособыВыплатыЗарплаты.ПустаяСсылка.Получить((byte[])Читалка.GetValue(5));
							Ссылка.Комментарий = Читалка.GetString(7);
							Ссылка.ДнейНеВыплаты = Читалка.GetDecimal(8);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(9);
							Ссылка.ХарактерВыплаты = V82.Перечисления/*Ссылка*/.ХарактерВыплатыЗарплаты.ПустаяСсылка.Получить((byte[])Читалка.GetValue(10));
							Ссылка.ДатаНачала = Читалка.GetDateTime(15);
							Ссылка.ДатаОкончания = Читалка.GetDateTime(16);
							Ссылка.ПроцентВыплаты = Читалка.GetDecimal(18);
							Ссылка.ПредварительныйУчетУдержаний = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.Округление = V82.Перечисления/*Ссылка*/.СпособыОкругленияЗарплатыКВыплате.ПустаяСсылка.Получить((byte[])Читалка.GetValue(20));
							Ссылка.СуммаДокумента = Читалка.GetDecimal(21);
							Ссылка.ДанныеПрошлойВерсии = ((byte[])Читалка.GetValue(22))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.ЗарплатаКВыплатеОрганизаций ВыбратьПоНомеру(int Первые,string Мин,string Макс)
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = string.Format(@"Select top {0} 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_Fld4683RRef [Организация]
					,_Fld4684 [ПериодРегистрации]
					,_Fld4685RRef [СпособВыплаты]
					,_Fld4686RRef [Ответственный]
					,_Fld4687 [Комментарий]
					,_Fld4688 [ДнейНеВыплаты]
					,_Fld4689 [КраткийСоставДокумента]
					,_Fld4690RRef [ХарактерВыплаты]
					,_Fld4691RRef [ПодразделениеОрганизации]
					,_Fld4692_TYPE [ДокументОснование_Тип],_Fld4692_RRRef [ДокументОснование],_Fld4692_RTRef [ДокументОснование_Вид]
					,_Fld4693 [ДатаНачала]
					,_Fld4694 [ДатаОкончания]
					,_Fld21437RRef [Банк]
					,_Fld26732 [ПроцентВыплаты]
					,_Fld26733 [ПредварительныйУчетУдержаний]
					,_Fld26734RRef [Округление]
					,_Fld26735 [СуммаДокумента]
					,_Fld26736 [ДанныеПрошлойВерсии]
					From _Document268(NOLOCK)
					Where _Code between @Мин and @Макс
					Order by _Code", Первые);
					Команда.Parameters.AddWithValue("Мин", Мин);
					Команда.Parameters.AddWithValue("Макс", Макс);
					var Выборка = new V82.ДокументыВыборка.ЗарплатаКВыплатеОрганизаций();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ЗарплатаКВыплатеОрганизаций();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(4);
							Ссылка.СпособВыплаты = V82.Перечисления/*Ссылка*/.СпособыВыплатыЗарплаты.ПустаяСсылка.Получить((byte[])Читалка.GetValue(5));
							Ссылка.Комментарий = Читалка.GetString(7);
							Ссылка.ДнейНеВыплаты = Читалка.GetDecimal(8);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(9);
							Ссылка.ХарактерВыплаты = V82.Перечисления/*Ссылка*/.ХарактерВыплатыЗарплаты.ПустаяСсылка.Получить((byte[])Читалка.GetValue(10));
							Ссылка.ДатаНачала = Читалка.GetDateTime(15);
							Ссылка.ДатаОкончания = Читалка.GetDateTime(16);
							Ссылка.ПроцентВыплаты = Читалка.GetDecimal(18);
							Ссылка.ПредварительныйУчетУдержаний = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.Округление = V82.Перечисления/*Ссылка*/.СпособыОкругленияЗарплатыКВыплате.ПустаяСсылка.Получить((byte[])Читалка.GetValue(20));
							Ссылка.СуммаДокумента = Читалка.GetDecimal(21);
							Ссылка.ДанныеПрошлойВерсии = ((byte[])Читалка.GetValue(22))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.ЗарплатаКВыплатеОрганизаций СтраницаПоСсылке(int Размер,int Номер)
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = @"Select top 1000 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_Fld4683RRef [Организация]
					,_Fld4684 [ПериодРегистрации]
					,_Fld4685RRef [СпособВыплаты]
					,_Fld4686RRef [Ответственный]
					,_Fld4687 [Комментарий]
					,_Fld4688 [ДнейНеВыплаты]
					,_Fld4689 [КраткийСоставДокумента]
					,_Fld4690RRef [ХарактерВыплаты]
					,_Fld4691RRef [ПодразделениеОрганизации]
					,_Fld4692_TYPE [ДокументОснование_Тип],_Fld4692_RRRef [ДокументОснование],_Fld4692_RTRef [ДокументОснование_Вид]
					,_Fld4693 [ДатаНачала]
					,_Fld4694 [ДатаОкончания]
					,_Fld21437RRef [Банк]
					,_Fld26732 [ПроцентВыплаты]
					,_Fld26733 [ПредварительныйУчетУдержаний]
					,_Fld26734RRef [Округление]
					,_Fld26735 [СуммаДокумента]
					,_Fld26736 [ДанныеПрошлойВерсии]
					From _Document268(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.ЗарплатаКВыплатеОрганизаций();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ЗарплатаКВыплатеОрганизаций();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(4);
							Ссылка.СпособВыплаты = V82.Перечисления/*Ссылка*/.СпособыВыплатыЗарплаты.ПустаяСсылка.Получить((byte[])Читалка.GetValue(5));
							Ссылка.Комментарий = Читалка.GetString(7);
							Ссылка.ДнейНеВыплаты = Читалка.GetDecimal(8);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(9);
							Ссылка.ХарактерВыплаты = V82.Перечисления/*Ссылка*/.ХарактерВыплатыЗарплаты.ПустаяСсылка.Получить((byte[])Читалка.GetValue(10));
							Ссылка.ДатаНачала = Читалка.GetDateTime(15);
							Ссылка.ДатаОкончания = Читалка.GetDateTime(16);
							Ссылка.ПроцентВыплаты = Читалка.GetDecimal(18);
							Ссылка.ПредварительныйУчетУдержаний = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.Округление = V82.Перечисления/*Ссылка*/.СпособыОкругленияЗарплатыКВыплате.ПустаяСсылка.Получить((byte[])Читалка.GetValue(20));
							Ссылка.СуммаДокумента = Читалка.GetDecimal(21);
							Ссылка.ДанныеПрошлойВерсии = ((byte[])Читалка.GetValue(22))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static ДокументыВыборка.ЗарплатаКВыплатеОрганизаций СтраницаПоНомеру(int Размер,int Номер)
		{
			using (var Подключение = new SqlConnection(СтрокаСоединения))
			{
				Подключение.Open();
				using (var Команда = Подключение.CreateCommand())
				{
					Команда.CommandText = @"Select top 1000 
					_IDRRef [Ссылка]
					,_Version [Версия]
					,_Marked [ПометкаУдаления]
					,_Fld4683RRef [Организация]
					,_Fld4684 [ПериодРегистрации]
					,_Fld4685RRef [СпособВыплаты]
					,_Fld4686RRef [Ответственный]
					,_Fld4687 [Комментарий]
					,_Fld4688 [ДнейНеВыплаты]
					,_Fld4689 [КраткийСоставДокумента]
					,_Fld4690RRef [ХарактерВыплаты]
					,_Fld4691RRef [ПодразделениеОрганизации]
					,_Fld4692_TYPE [ДокументОснование_Тип],_Fld4692_RRRef [ДокументОснование],_Fld4692_RTRef [ДокументОснование_Вид]
					,_Fld4693 [ДатаНачала]
					,_Fld4694 [ДатаОкончания]
					,_Fld21437RRef [Банк]
					,_Fld26732 [ПроцентВыплаты]
					,_Fld26733 [ПредварительныйУчетУдержаний]
					,_Fld26734RRef [Округление]
					,_Fld26735 [СуммаДокумента]
					,_Fld26736 [ДанныеПрошлойВерсии]
					From _Document268(NOLOCK)";
					var Выборка = new V82.ДокументыВыборка.ЗарплатаКВыплатеОрганизаций();
					using (var Читалка = Команда.ExecuteReader())
					{
						while (Читалка.Read())
						{
							var Ссылка = new ДокументыСсылка.ЗарплатаКВыплатеОрганизаций();
							//ToDo: Читать нужно через GetValues()
							Ссылка.Ссылка = new Guid((byte[])Читалка.GetValue(0));
							var ПотокВерсии = ((byte[])Читалка.GetValue(1));
							Array.Reverse(ПотокВерсии);
							Ссылка.Версия =  BitConverter.ToInt64(ПотокВерсии, 0);
							Ссылка.ВерсияДанных =  Convert.ToBase64String(ПотокВерсии);
							Ссылка.ПометкаУдаления = ((byte[])Читалка.GetValue(2))[0]==1;
							Ссылка.ПериодРегистрации = Читалка.GetDateTime(4);
							Ссылка.СпособВыплаты = V82.Перечисления/*Ссылка*/.СпособыВыплатыЗарплаты.ПустаяСсылка.Получить((byte[])Читалка.GetValue(5));
							Ссылка.Комментарий = Читалка.GetString(7);
							Ссылка.ДнейНеВыплаты = Читалка.GetDecimal(8);
							Ссылка.КраткийСоставДокумента = Читалка.GetString(9);
							Ссылка.ХарактерВыплаты = V82.Перечисления/*Ссылка*/.ХарактерВыплатыЗарплаты.ПустаяСсылка.Получить((byte[])Читалка.GetValue(10));
							Ссылка.ДатаНачала = Читалка.GetDateTime(15);
							Ссылка.ДатаОкончания = Читалка.GetDateTime(16);
							Ссылка.ПроцентВыплаты = Читалка.GetDecimal(18);
							Ссылка.ПредварительныйУчетУдержаний = ((byte[])Читалка.GetValue(19))[0]==1;
							Ссылка.Округление = V82.Перечисления/*Ссылка*/.СпособыОкругленияЗарплатыКВыплате.ПустаяСсылка.Получить((byte[])Читалка.GetValue(20));
							Ссылка.СуммаДокумента = Читалка.GetDecimal(21);
							Ссылка.ДанныеПрошлойВерсии = ((byte[])Читалка.GetValue(22))[0]==1;
							Выборка.Add(Ссылка);
						}
							return Выборка;
					}
				}
			}
		}
		
		public static V82.ДокументыОбъект.ЗарплатаКВыплатеОрганизаций СоздатьЭлемент()
		{
			var Объект = new V82.ДокументыОбъект.ЗарплатаКВыплатеОрганизаций();
			Объект._ЭтоНовый = true;
			Объект.Ссылка = Guid.NewGuid();/*http://msdn.microsoft.com/ru-ru/library/aa379322(VS.85).aspx*/
			Объект.Комментарий = "";
			Объект.КраткийСоставДокумента = "";
			Объект.СпособВыплаты = V82.Перечисления/*Ссылка*/.СпособыВыплатыЗарплаты.ПустаяСсылка;
			Объект.ХарактерВыплаты = V82.Перечисления/*Ссылка*/.ХарактерВыплатыЗарплаты.ПустаяСсылка;
			Объект.Округление = V82.Перечисления/*Ссылка*/.СпособыОкругленияЗарплатыКВыплате.ПустаяСсылка;
			return Объект;
		}
	}
}