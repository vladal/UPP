﻿Ext.require(['Данные.Обработки.РедактированиеДанныхРаспределения'], function () 
{
	Ext.define('Обработки.РедактированиеДанныхРаспределения.ФормаНастройки',
	{
	extend: 'Ext.window.Window',
	style: 'position:absolute;width:790px;height:510px;',
	iconCls: 'bogus',
	minimizable: true,
	maximizable: true,
	resizable: false,
	title: 'Настройки отображения данных',
	
	layout: {type: "fit",align: "stretch"},
	items:
	[{
		xtype: 'form',
		items:
		[
		{
			id: 'КомпоновщикНастроекНастройки',
			xtype: 'grid',
			style: 'position:absolute;left:8px;top:7px;width:749px;height:225px;',
			height: 225,width: 749,
			columns:
			[
				{
					text:'Заголовок',
					width:'100',
					dataIndex:'Заголовок',
					flex:1,
				},
				{
					text:'',
					width:'20',
					dataIndex:'Выбор',
					flex:1,
				},
				{
					text:'',
					width:'20',
					dataIndex:'Отбор',
					flex:1,
				},
				{
					text:'',
					width:'20',
					dataIndex:'Порядок',
					flex:1,
				},
				{
					text:'',
					width:'20',
					dataIndex:'УсловноеОформление',
					flex:1,
				},
				{
					text:'',
					width:'20',
					dataIndex:'ПараметрыВывода',
					flex:1,
				},
			],
			store:
			{
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/РедактированиеДанныхРаспределения/ВыбратьПоСсылке/100', timeout: 200},
				fields:
				[
					{
						name:'Ссылка',
					},
					{
						name:'Заголовок',
					},
					{
						name:'Выбор',
					},
					{
						name:'Отбор',
					},
					{
						name:'Порядок',
					},
					{
						name:'УсловноеОформление',
					},
					{
						name:'ПараметрыВывода',
					},
				]
			},
			listeners:
			{
				dblclick:
				{
					element: 'body',
					fn: function ()
					{
						var грид = Ext.getCmp('КомпоновщикНастроекНастройки');
						var ссылка = грид.getView().getSelectionModel().getSelection()[0].data.Ссылка;
						var Хранилище = грид.store;
						var стрЗнач = Хранилище.findRecord('Ссылка', ссылка).data;
						Ext.require(['Справочники.РедактированиеДанныхРаспределения.ФормаНастройкиСобытия'], function ()
						{
							var obj = Ext.create("Справочники.РедактированиеДанныхРаспределения.ФормаНастройкиСобытия");
							obj.ПередатьСсылку(стрЗнач);
						});
					}
				}
			},
		},
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:759px;top:7px;width:24px;height:225px;',
			items:
			[
			]
		},
		{
			xtype: 'label',
			name: 'НадписьНастройки',
			text: 'Настройки : ',
			style: 'position:absolute;left:8px;top:237px;width:70px;height:24px;',
		},
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:78px;top:237px;width:704px;height:24px;',
			items:
			[
				{
					text:'Текущий отчет',
				},
				{
					text:'Текущий элемент структуры настроек',
				},
			]
		},
		{
			xtype: 'tabpanel',
			style: 'position:absolute;left:8px;top:262px;width:774px;height:219px;',
			height: 219,width: 774,
			items:
			[
				{
					title:'Параметры данных',
					items:
					[
		{
			id: 'ПараметрыДанных',
			xtype: 'grid',
			style: 'position:absolute;left:6px;top:6px;width:735px;height:187px;',
			height: 187,width: 735,
			columns:
			[
				{
					text:'',
					width:'20',
					dataIndex:'Использование',
					flex:1,
				},
				{
					text:'Параметр',
					width:'100',
					dataIndex:'Параметр',
					flex:1,
				},
				{
					text:'Значение',
					width:'100',
					dataIndex:'Значение',
					flex:1,
				},
				{
					text:'Параметр',
					width:'100',
					dataIndex:'ПараметрСДатой',
					flex:1,
				},
				{
					text:'Значение',
					width:'50',
					dataIndex:'ЗначениеСДатой',
					flex:1,
				},
				{
					text:'Дата',
					width:'50',
					dataIndex:'ДатаЗначениеСДатой',
					flex:1,
				},
				{
					text:'Дата начала',
					width:'100',
					dataIndex:'ДатаНачала',
					flex:1,
				},
				{
					text:'Дата окончания',
					width:'100',
					dataIndex:'ДатаОкончания',
					flex:1,
				},
			],
			store:
			{
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/РедактированиеДанныхРаспределения/ВыбратьПоСсылке/100', timeout: 200},
				fields:
				[
					{
						name:'Ссылка',
					},
					{
						name:'Использование',
					},
					{
						name:'Параметр',
					},
					{
						name:'Значение',
					},
					{
						name:'ПараметрСДатой',
					},
					{
						name:'ЗначениеСДатой',
					},
					{
						name:'ДатаЗначениеСДатой',
					},
					{
						name:'ДатаНачала',
					},
					{
						name:'ДатаОкончания',
					},
				]
			},
			listeners:
			{
				dblclick:
				{
					element: 'body',
					fn: function ()
					{
						var грид = Ext.getCmp('ПараметрыДанных');
						var ссылка = грид.getView().getSelectionModel().getSelection()[0].data.Ссылка;
						var Хранилище = грид.store;
						var стрЗнач = Хранилище.findRecord('Ссылка', ссылка).data;
						Ext.require(['Справочники.РедактированиеДанныхРаспределения.ФормаНастройкиСобытия'], function ()
						{
							var obj = Ext.create("Справочники.РедактированиеДанныхРаспределения.ФормаНастройкиСобытия");
							obj.ПередатьСсылку(стрЗнач);
						});
					}
				}
			},
		},
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:743px;top:6px;width:24px;height:187px;',
			items:
			[
			]
		},
					]
				},
				{
					title:'Поля группировки',
					items:
					[
		{
			id: 'ДоступныеПоляПолейГруппировок',
			xtype: 'grid',
			style: 'position:absolute;left:6px;top:6px;width:262px;height:187px;',
			height: 187,width: 262,
			columns:
			[
				{
					text:'Доступные поля',
					width:'100',
					dataIndex:'Заголовок',
					flex:1,
				},
			],
			store:
			{
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/РедактированиеДанныхРаспределения/ВыбратьПоСсылке/100', timeout: 200},
				fields:
				[
					{
						name:'Ссылка',
					},
					{
						name:'Заголовок',
					},
				]
			},
			listeners:
			{
				dblclick:
				{
					element: 'body',
					fn: function ()
					{
						var грид = Ext.getCmp('ДоступныеПоляПолейГруппировок');
						var ссылка = грид.getView().getSelectionModel().getSelection()[0].data.Ссылка;
						var Хранилище = грид.store;
						var стрЗнач = Хранилище.findRecord('Ссылка', ссылка).data;
						Ext.require(['Справочники.РедактированиеДанныхРаспределения.ФормаНастройкиСобытия'], function ()
						{
							var obj = Ext.create("Справочники.РедактированиеДанныхРаспределения.ФормаНастройкиСобытия");
							obj.ПередатьСсылку(стрЗнач);
						});
					}
				}
			},
		},
		{
			id: 'ПоляГруппировки',
			xtype: 'grid',
			style: 'position:absolute;left:275px;top:6px;width:466px;height:187px;',
			height: 187,width: 466,
			columns:
			[
				{
					text:'',
					width:'20',
					dataIndex:'Использование',
					flex:1,
				},
				{
					text:'Поле',
					width:'100',
					dataIndex:'Поле',
					flex:1,
				},
				{
					text:'Тип группировки',
					width:'100',
					dataIndex:'ТипГруппировки',
					flex:1,
				},
				{
					text:'Поле',
					width:'100',
					dataIndex:'ПолеДляДаты',
					flex:1,
				},
				{
					text:'Тип дополнения',
					width:'100',
					dataIndex:'ТипДополнения',
					flex:1,
				},
				{
					text:'Начальная дата периода',
					width:'100',
					dataIndex:'НачалоПериода',
					flex:1,
				},
				{
					text:'Конечная дата периода',
					width:'100',
					dataIndex:'КонецПериода',
					flex:1,
				},
			],
			store:
			{
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/РедактированиеДанныхРаспределения/ВыбратьПоСсылке/100', timeout: 200},
				fields:
				[
					{
						name:'Ссылка',
					},
					{
						name:'Использование',
					},
					{
						name:'Поле',
					},
					{
						name:'ТипГруппировки',
					},
					{
						name:'ПолеДляДаты',
					},
					{
						name:'ТипДополнения',
					},
					{
						name:'НачалоПериода',
					},
					{
						name:'КонецПериода',
					},
				]
			},
			listeners:
			{
				dblclick:
				{
					element: 'body',
					fn: function ()
					{
						var грид = Ext.getCmp('ПоляГруппировки');
						var ссылка = грид.getView().getSelectionModel().getSelection()[0].data.Ссылка;
						var Хранилище = грид.store;
						var стрЗнач = Хранилище.findRecord('Ссылка', ссылка).data;
						Ext.require(['Справочники.РедактированиеДанныхРаспределения.ФормаНастройкиСобытия'], function ()
						{
							var obj = Ext.create("Справочники.РедактированиеДанныхРаспределения.ФормаНастройкиСобытия");
							obj.ПередатьСсылку(стрЗнач);
						});
					}
				}
			},
		},
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:743px;top:6px;width:24px;height:187px;',
			items:
			[
			]
		},
					]
				},
				{
					title:'Выбранные поля',
					items:
					[
		{
			id: 'ДоступныеПоляВыбора',
			xtype: 'grid',
			style: 'position:absolute;left:6px;top:6px;width:262px;height:187px;',
			height: 187,width: 262,
			columns:
			[
				{
					text:'Доступные поля',
					width:'100',
					dataIndex:'Заголовок',
					flex:1,
				},
			],
			store:
			{
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/РедактированиеДанныхРаспределения/ВыбратьПоСсылке/100', timeout: 200},
				fields:
				[
					{
						name:'Ссылка',
					},
					{
						name:'Заголовок',
					},
				]
			},
			listeners:
			{
				dblclick:
				{
					element: 'body',
					fn: function ()
					{
						var грид = Ext.getCmp('ДоступныеПоляВыбора');
						var ссылка = грид.getView().getSelectionModel().getSelection()[0].data.Ссылка;
						var Хранилище = грид.store;
						var стрЗнач = Хранилище.findRecord('Ссылка', ссылка).data;
						Ext.require(['Справочники.РедактированиеДанныхРаспределения.ФормаНастройкиСобытия'], function ()
						{
							var obj = Ext.create("Справочники.РедактированиеДанныхРаспределения.ФормаНастройкиСобытия");
							obj.ПередатьСсылку(стрЗнач);
						});
					}
				}
			},
		},
		{
			id: 'Выбор',
			xtype: 'grid',
			style: 'position:absolute;left:275px;top:6px;width:466px;height:187px;',
			height: 187,width: 466,
			columns:
			[
				{
					text:'',
					width:'20',
					dataIndex:'Использование',
					flex:1,
				},
				{
					text:'Заголовок',
					width:'100',
					dataIndex:'Заголовок',
					flex:1,
				},
				{
					text:'Расположение',
					width:'100',
					dataIndex:'Расположение',
					flex:1,
				},
				{
					text:'Поле',
					width:'100',
					dataIndex:'Поле',
					flex:1,
				},
			],
			store:
			{
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/РедактированиеДанныхРаспределения/ВыбратьПоСсылке/100', timeout: 200},
				fields:
				[
					{
						name:'Ссылка',
					},
					{
						name:'Использование',
					},
					{
						name:'Заголовок',
					},
					{
						name:'Расположение',
					},
					{
						name:'Поле',
					},
				]
			},
			listeners:
			{
				dblclick:
				{
					element: 'body',
					fn: function ()
					{
						var грид = Ext.getCmp('Выбор');
						var ссылка = грид.getView().getSelectionModel().getSelection()[0].data.Ссылка;
						var Хранилище = грид.store;
						var стрЗнач = Хранилище.findRecord('Ссылка', ссылка).data;
						Ext.require(['Справочники.РедактированиеДанныхРаспределения.ФормаНастройкиСобытия'], function ()
						{
							var obj = Ext.create("Справочники.РедактированиеДанныхРаспределения.ФормаНастройкиСобытия");
							obj.ПередатьСсылку(стрЗнач);
						});
					}
				}
			},
		},
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:743px;top:6px;width:24px;height:187px;',
			items:
			[
			]
		},
					]
				},
				{
					title:'Отбор',
					items:
					[
		{
			id: 'ДоступныеПоляОтбора',
			xtype: 'grid',
			style: 'position:absolute;left:6px;top:6px;width:262px;height:187px;',
			height: 187,width: 262,
			columns:
			[
				{
					text:'Доступные поля',
					width:'100',
					dataIndex:'Заголовок',
					flex:1,
				},
			],
			store:
			{
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/РедактированиеДанныхРаспределения/ВыбратьПоСсылке/100', timeout: 200},
				fields:
				[
					{
						name:'Ссылка',
					},
					{
						name:'Заголовок',
					},
				]
			},
			listeners:
			{
				dblclick:
				{
					element: 'body',
					fn: function ()
					{
						var грид = Ext.getCmp('ДоступныеПоляОтбора');
						var ссылка = грид.getView().getSelectionModel().getSelection()[0].data.Ссылка;
						var Хранилище = грид.store;
						var стрЗнач = Хранилище.findRecord('Ссылка', ссылка).data;
						Ext.require(['Справочники.РедактированиеДанныхРаспределения.ФормаНастройкиСобытия'], function ()
						{
							var obj = Ext.create("Справочники.РедактированиеДанныхРаспределения.ФормаНастройкиСобытия");
							obj.ПередатьСсылку(стрЗнач);
						});
					}
				}
			},
		},
		{
			id: 'Отбор',
			xtype: 'grid',
			style: 'position:absolute;left:275px;top:6px;width:466px;height:187px;',
			height: 187,width: 466,
			columns:
			[
				{
					text:'',
					width:'20',
					dataIndex:'Использование',
					flex:1,
				},
				{
					text:'Левое значение',
					width:'100',
					dataIndex:'ЛевоеЗначениеДляПодробногоОтображенияЭлемента',
					flex:1,
				},
				{
					text:'Вид сравнения',
					width:'75',
					dataIndex:'ВидыСравненияДляПодробногоОтображенияЭлемента',
					flex:1,
				},
				{
					text:'Правое значение',
					width:'100',
					dataIndex:'ПравоеЗначениеДляПодробногоОтображенияЭлемента',
					flex:1,
				},
				{
					text:'Представление',
					width:'100',
					dataIndex:'ПредставлениеДляПодробногоОтображенияЭлемента',
					flex:1,
				},
				{
					text:'Представление',
					width:'100',
					dataIndex:'ПредставлениеДляКраткогоОтображенияЭлемента',
					flex:1,
				},
				{
					text:'Левое значение',
					width:'100',
					dataIndex:'ЛевоеЗначениеДляКраткогоОтображенияЭлемента',
					flex:1,
				},
				{
					text:'Вид сравнения',
					width:'75',
					dataIndex:'ВидыСравненияДляКраткогоОтображенияЭлемента',
					flex:1,
				},
				{
					text:'Правое значение',
					width:'100',
					dataIndex:'ПравоеЗначениеДляКраткогоОтображенияЭлемента',
					flex:1,
				},
				{
					text:'Тип группы',
					width:'275',
					dataIndex:'ТипДляПодробногоОтображенияГруппы',
					flex:1,
				},
				{
					text:'Представление',
					width:'100',
					dataIndex:'ПредставлениеДляПодробногоОтображенияГруппы',
					flex:1,
				},
				{
					text:'Тип группы',
					width:'275',
					dataIndex:'ТипДляКраткогоОтображенияГруппы',
					flex:1,
				},
				{
					text:'Левое значение',
					width:'100',
					dataIndex:'ЛевоеЗначениеДляПодробногоОтображенияЭлементаЛокальногоОтбора',
					flex:1,
				},
				{
					text:'Вид сравнения',
					width:'75',
					dataIndex:'ВидыСравненияДляПодробногоОтображенияЭлементаЛокальногоОтбора',
					flex:1,
				},
				{
					text:'Правое значение',
					width:'100',
					dataIndex:'ПравоеЗначениеДляПодробногоОтображенияЭлементаЛокальногоОтбора',
					flex:1,
				},
				{
					text:'Применение',
					width:'75',
					dataIndex:'ПрименениеДляПодробногоОтображенияЭлементаЛокальногоОтбора',
					flex:1,
				},
				{
					text:'Представление',
					width:'100',
					dataIndex:'ПредставлениеДляПодробногоОтображенияЭлементаЛокальногоОтбора',
					flex:1,
				},
				{
					text:'Левое значение',
					width:'100',
					dataIndex:'ЛевоеЗначениеДляКраткогоОтображенияЭлементаЛокальногоОтбора',
					flex:1,
				},
				{
					text:'Вид сравнения',
					width:'75',
					dataIndex:'ВидыСравненияДляКраткогоОтображенияЭлементаЛокальногоОтбора',
					flex:1,
				},
				{
					text:'Правое значение',
					width:'100',
					dataIndex:'ПравоеЗначениеДляКраткогоОтображенияЭлементаЛокальногоОтбора',
					flex:1,
				},
				{
					text:'Применение',
					width:'75',
					dataIndex:'ПрименениеДляКраткогоОтображенияЭлементаЛокальногоОтбора',
					flex:1,
				},
				{
					text:'Тип группы',
					width:'275',
					dataIndex:'ТипДляПодробногоОтображенияГруппыЛокальногоОтбора',
					flex:1,
				},
				{
					text:'Применение',
					width:'75',
					dataIndex:'ПрименениеДляПодробногоОтображенияГруппыЛокальногоОтбора',
					flex:1,
				},
				{
					text:'Представление',
					width:'100',
					dataIndex:'ПредставлениеДляПодробногоОтображенияГруппыЛокальногоОтбора',
					flex:1,
				},
				{
					text:'Тип группы',
					width:'275',
					dataIndex:'ТипДляКраткогоОтображенияГруппыЛокальногоОтбора',
					flex:1,
				},
				{
					text:'Применение',
					width:'75',
					dataIndex:'ПрименениеДляКраткогоОтображенияГруппыЛокальногоОтбора',
					flex:1,
				},
				{
					text:'Левое значение',
					width:'100',
					dataIndex:'ЛевоеЗначениеДляПодробногоОтображенияЭлементаГлавногоОтбора',
					flex:1,
				},
				{
					text:'Вид сравнения',
					width:'75',
					dataIndex:'ВидыСравненияДляПодробногоОтображенияЭлементаГлавногоОтбора',
					flex:1,
				},
				{
					text:'Правое значение',
					width:'100',
					dataIndex:'ПравоеЗначениеДляПодробногоОтображенияЭлементаГлавногоОтбора',
					flex:1,
				},
				{
					text:'Режим отображения',
					width:'75',
					dataIndex:'РежимОтображенияДляПодробногоОтображенияЭлементаГлавногоОтбора',
					flex:1,
				},
				{
					text:'Представление',
					width:'100',
					dataIndex:'ПредставлениеДляПодробногоОтображенияЭлементаГлавногоОтбора',
					flex:1,
				},
				{
					text:'Тип группы',
					width:'275',
					dataIndex:'ТипДляПодробногоОтображенияГруппыГлавногоОтбора',
					flex:1,
				},
				{
					text:'Режим отображения',
					width:'75',
					dataIndex:'РежимОтображенияДляПодробногоОтображенияГруппыГлавногоОтбора',
					flex:1,
				},
				{
					text:'Представление',
					width:'100',
					dataIndex:'ПредставлениеДляПодробногоОтображенияГруппыГлавногоОтбора',
					flex:1,
				},
				{
					text:'Левое значение',
					width:'100',
					dataIndex:'ЛевоеЗначениеДляПодробногоОтображенияЭлементаСДатой',
					flex:1,
				},
				{
					text:'Вид сравнения',
					width:'75',
					dataIndex:'ВидыСравненияДляПодробногоОтображенияЭлементаСДатой',
					flex:1,
				},
				{
					text:'Правое значение',
					width:'50',
					dataIndex:'ПравоеЗначениеДляПодробногоОтображенияЭлементаСДатой',
					flex:1,
				},
				{
					text:'Дата',
					width:'50',
					dataIndex:'ДатаПравоеЗначениеДляПодробногоОтображенияЭлементаСДатой',
					flex:1,
				},
				{
					text:'Представление',
					width:'100',
					dataIndex:'ПредставлениеДляПодробногоОтображенияЭлементаСДатой',
					flex:1,
				},
				{
					text:'Левое значение',
					width:'100',
					dataIndex:'ЛевоеЗначениеДляКраткогоОтображенияЭлементаСДатой',
					flex:1,
				},
				{
					text:'Вид сравнения',
					width:'75',
					dataIndex:'ВидыСравненияДляКраткогоОтображенияЭлементаСДатой',
					flex:1,
				},
				{
					text:'Правое значение',
					width:'50',
					dataIndex:'ПравоеЗначениеДляКраткогоОтображенияЭлементаСДатой',
					flex:1,
				},
				{
					text:'Дата',
					width:'50',
					dataIndex:'ДатаПравоеЗначениеДляКраткогоОтображенияЭлементаСДатой',
					flex:1,
				},
				{
					text:'Левое значение',
					width:'100',
					dataIndex:'ЛевоеЗначениеДляПодробногоОтображенияЭлементаЛокальногоОтбораСДатой',
					flex:1,
				},
				{
					text:'Вид сравнения',
					width:'75',
					dataIndex:'ВидыСравненияДляПодробногоОтображенияЭлементаЛокальногоОтбораСДатой',
					flex:1,
				},
				{
					text:'Правое значение',
					width:'50',
					dataIndex:'ПравоеЗначениеДляПодробногоОтображенияЭлементаЛокальногоОтбораСДатой',
					flex:1,
				},
				{
					text:'Дата',
					width:'50',
					dataIndex:'ДатаПравоеЗначениеДляПодробногоОтображенияЭлементаЛокальногоОтбораСДатой',
					flex:1,
				},
				{
					text:'Применение',
					width:'75',
					dataIndex:'ПрименениеДляПодробногоОтображенияЭлементаЛокальногоОтбораСДатой',
					flex:1,
				},
				{
					text:'Представление',
					width:'100',
					dataIndex:'ПредставлениеДляПодробногоОтображенияЭлементаЛокальногоОтбораСДатой',
					flex:1,
				},
				{
					text:'Левое значение',
					width:'100',
					dataIndex:'ЛевоеЗначениеДляКраткогоОтображенияЭлементаЛокальногоОтбораСДатой',
					flex:1,
				},
				{
					text:'Вид сравнения',
					width:'75',
					dataIndex:'ВидыСравненияДляКраткогоОтображенияЭлементаЛокальногоОтбораСДатой',
					flex:1,
				},
				{
					text:'Правое значение',
					width:'50',
					dataIndex:'ПравоеЗначениеДляКраткогоОтображенияЭлементаЛокальногоОтбораСДатой',
					flex:1,
				},
				{
					text:'Дата',
					width:'50',
					dataIndex:'ДатаПравоеЗначениеДляКраткогоОтображенияЭлементаЛокальногоОтбораСДатой',
					flex:1,
				},
				{
					text:'Применение',
					width:'75',
					dataIndex:'ПрименениеДляКраткогоОтображенияЭлементаЛокальногоОтбораСДатой',
					flex:1,
				},
				{
					text:'Левое значение',
					width:'100',
					dataIndex:'ЛевоеЗначениеДляПодробногоОтображенияЭлементаГлавногоОтбораСДатой',
					flex:1,
				},
				{
					text:'Вид сравнения',
					width:'75',
					dataIndex:'ВидыСравненияДляПодробногоОтображенияЭлементаГлавногоОтбораСДатой',
					flex:1,
				},
				{
					text:'Правое значение',
					width:'50',
					dataIndex:'ПравоеЗначениеДляПодробногоОтображенияЭлементаГлавногоОтбораСДатой',
					flex:1,
				},
				{
					text:'Дата',
					width:'50',
					dataIndex:'ДатаПравоеЗначениеДляПодробногоОтображенияЭлементаГлавногоОтбораСДатой',
					flex:1,
				},
				{
					text:'Режим отображения',
					width:'75',
					dataIndex:'РежимОтображенияДляПодробногоОтображенияЭлементаГлавногоОтбораСДатой',
					flex:1,
				},
				{
					text:'Представление',
					width:'100',
					dataIndex:'ПредставлениеДляПодробногоОтображенияЭлементаГлавногоОтбораСДатой',
					flex:1,
				},
			],
			store:
			{
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/РедактированиеДанныхРаспределения/ВыбратьПоСсылке/100', timeout: 200},
				fields:
				[
					{
						name:'Ссылка',
					},
					{
						name:'Использование',
					},
					{
						name:'ЛевоеЗначениеДляПодробногоОтображенияЭлемента',
					},
					{
						name:'ВидыСравненияДляПодробногоОтображенияЭлемента',
					},
					{
						name:'ПравоеЗначениеДляПодробногоОтображенияЭлемента',
					},
					{
						name:'ПредставлениеДляПодробногоОтображенияЭлемента',
					},
					{
						name:'ПредставлениеДляКраткогоОтображенияЭлемента',
					},
					{
						name:'ЛевоеЗначениеДляКраткогоОтображенияЭлемента',
					},
					{
						name:'ВидыСравненияДляКраткогоОтображенияЭлемента',
					},
					{
						name:'ПравоеЗначениеДляКраткогоОтображенияЭлемента',
					},
					{
						name:'ТипДляПодробногоОтображенияГруппы',
					},
					{
						name:'ПредставлениеДляПодробногоОтображенияГруппы',
					},
					{
						name:'ТипДляКраткогоОтображенияГруппы',
					},
					{
						name:'ЛевоеЗначениеДляПодробногоОтображенияЭлементаЛокальногоОтбора',
					},
					{
						name:'ВидыСравненияДляПодробногоОтображенияЭлементаЛокальногоОтбора',
					},
					{
						name:'ПравоеЗначениеДляПодробногоОтображенияЭлементаЛокальногоОтбора',
					},
					{
						name:'ПрименениеДляПодробногоОтображенияЭлементаЛокальногоОтбора',
					},
					{
						name:'ПредставлениеДляПодробногоОтображенияЭлементаЛокальногоОтбора',
					},
					{
						name:'ЛевоеЗначениеДляКраткогоОтображенияЭлементаЛокальногоОтбора',
					},
					{
						name:'ВидыСравненияДляКраткогоОтображенияЭлементаЛокальногоОтбора',
					},
					{
						name:'ПравоеЗначениеДляКраткогоОтображенияЭлементаЛокальногоОтбора',
					},
					{
						name:'ПрименениеДляКраткогоОтображенияЭлементаЛокальногоОтбора',
					},
					{
						name:'ТипДляПодробногоОтображенияГруппыЛокальногоОтбора',
					},
					{
						name:'ПрименениеДляПодробногоОтображенияГруппыЛокальногоОтбора',
					},
					{
						name:'ПредставлениеДляПодробногоОтображенияГруппыЛокальногоОтбора',
					},
					{
						name:'ТипДляКраткогоОтображенияГруппыЛокальногоОтбора',
					},
					{
						name:'ПрименениеДляКраткогоОтображенияГруппыЛокальногоОтбора',
					},
					{
						name:'ЛевоеЗначениеДляПодробногоОтображенияЭлементаГлавногоОтбора',
					},
					{
						name:'ВидыСравненияДляПодробногоОтображенияЭлементаГлавногоОтбора',
					},
					{
						name:'ПравоеЗначениеДляПодробногоОтображенияЭлементаГлавногоОтбора',
					},
					{
						name:'РежимОтображенияДляПодробногоОтображенияЭлементаГлавногоОтбора',
					},
					{
						name:'ПредставлениеДляПодробногоОтображенияЭлементаГлавногоОтбора',
					},
					{
						name:'ТипДляПодробногоОтображенияГруппыГлавногоОтбора',
					},
					{
						name:'РежимОтображенияДляПодробногоОтображенияГруппыГлавногоОтбора',
					},
					{
						name:'ПредставлениеДляПодробногоОтображенияГруппыГлавногоОтбора',
					},
					{
						name:'ЛевоеЗначениеДляПодробногоОтображенияЭлементаСДатой',
					},
					{
						name:'ВидыСравненияДляПодробногоОтображенияЭлементаСДатой',
					},
					{
						name:'ПравоеЗначениеДляПодробногоОтображенияЭлементаСДатой',
					},
					{
						name:'ДатаПравоеЗначениеДляПодробногоОтображенияЭлементаСДатой',
					},
					{
						name:'ПредставлениеДляПодробногоОтображенияЭлементаСДатой',
					},
					{
						name:'ЛевоеЗначениеДляКраткогоОтображенияЭлементаСДатой',
					},
					{
						name:'ВидыСравненияДляКраткогоОтображенияЭлементаСДатой',
					},
					{
						name:'ПравоеЗначениеДляКраткогоОтображенияЭлементаСДатой',
					},
					{
						name:'ДатаПравоеЗначениеДляКраткогоОтображенияЭлементаСДатой',
					},
					{
						name:'ЛевоеЗначениеДляПодробногоОтображенияЭлементаЛокальногоОтбораСДатой',
					},
					{
						name:'ВидыСравненияДляПодробногоОтображенияЭлементаЛокальногоОтбораСДатой',
					},
					{
						name:'ПравоеЗначениеДляПодробногоОтображенияЭлементаЛокальногоОтбораСДатой',
					},
					{
						name:'ДатаПравоеЗначениеДляПодробногоОтображенияЭлементаЛокальногоОтбораСДатой',
					},
					{
						name:'ПрименениеДляПодробногоОтображенияЭлементаЛокальногоОтбораСДатой',
					},
					{
						name:'ПредставлениеДляПодробногоОтображенияЭлементаЛокальногоОтбораСДатой',
					},
					{
						name:'ЛевоеЗначениеДляКраткогоОтображенияЭлементаЛокальногоОтбораСДатой',
					},
					{
						name:'ВидыСравненияДляКраткогоОтображенияЭлементаЛокальногоОтбораСДатой',
					},
					{
						name:'ПравоеЗначениеДляКраткогоОтображенияЭлементаЛокальногоОтбораСДатой',
					},
					{
						name:'ДатаПравоеЗначениеДляКраткогоОтображенияЭлементаЛокальногоОтбораСДатой',
					},
					{
						name:'ПрименениеДляКраткогоОтображенияЭлементаЛокальногоОтбораСДатой',
					},
					{
						name:'ЛевоеЗначениеДляПодробногоОтображенияЭлементаГлавногоОтбораСДатой',
					},
					{
						name:'ВидыСравненияДляПодробногоОтображенияЭлементаГлавногоОтбораСДатой',
					},
					{
						name:'ПравоеЗначениеДляПодробногоОтображенияЭлементаГлавногоОтбораСДатой',
					},
					{
						name:'ДатаПравоеЗначениеДляПодробногоОтображенияЭлементаГлавногоОтбораСДатой',
					},
					{
						name:'РежимОтображенияДляПодробногоОтображенияЭлементаГлавногоОтбораСДатой',
					},
					{
						name:'ПредставлениеДляПодробногоОтображенияЭлементаГлавногоОтбораСДатой',
					},
				]
			},
			listeners:
			{
				dblclick:
				{
					element: 'body',
					fn: function ()
					{
						var грид = Ext.getCmp('Отбор');
						var ссылка = грид.getView().getSelectionModel().getSelection()[0].data.Ссылка;
						var Хранилище = грид.store;
						var стрЗнач = Хранилище.findRecord('Ссылка', ссылка).data;
						Ext.require(['Справочники.РедактированиеДанныхРаспределения.ФормаНастройкиСобытия'], function ()
						{
							var obj = Ext.create("Справочники.РедактированиеДанныхРаспределения.ФормаНастройкиСобытия");
							obj.ПередатьСсылку(стрЗнач);
						});
					}
				}
			},
		},
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:743px;top:6px;width:24px;height:187px;',
			items:
			[
			]
		},
					]
				},
				{
					title:'Сортировка',
					items:
					[
		{
			id: 'ДоступныеПоляПорядка',
			xtype: 'grid',
			style: 'position:absolute;left:6px;top:6px;width:262px;height:187px;',
			height: 187,width: 262,
			columns:
			[
				{
					text:'Доступные поля',
					width:'100',
					dataIndex:'Заголовок',
					flex:1,
				},
			],
			store:
			{
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/РедактированиеДанныхРаспределения/ВыбратьПоСсылке/100', timeout: 200},
				fields:
				[
					{
						name:'Ссылка',
					},
					{
						name:'Заголовок',
					},
				]
			},
			listeners:
			{
				dblclick:
				{
					element: 'body',
					fn: function ()
					{
						var грид = Ext.getCmp('ДоступныеПоляПорядка');
						var ссылка = грид.getView().getSelectionModel().getSelection()[0].data.Ссылка;
						var Хранилище = грид.store;
						var стрЗнач = Хранилище.findRecord('Ссылка', ссылка).data;
						Ext.require(['Справочники.РедактированиеДанныхРаспределения.ФормаНастройкиСобытия'], function ()
						{
							var obj = Ext.create("Справочники.РедактированиеДанныхРаспределения.ФормаНастройкиСобытия");
							obj.ПередатьСсылку(стрЗнач);
						});
					}
				}
			},
		},
		{
			id: 'Порядок',
			xtype: 'grid',
			style: 'position:absolute;left:275px;top:6px;width:466px;height:187px;',
			height: 187,width: 466,
			columns:
			[
				{
					text:'',
					width:'20',
					dataIndex:'Использование',
					flex:1,
				},
				{
					text:'Поле',
					width:'100',
					dataIndex:'Поле',
					flex:1,
				},
				{
					text:'Направление сортировки',
					width:'100',
					dataIndex:'ТипУпорядочивания',
					flex:1,
				},
			],
			store:
			{
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/РедактированиеДанныхРаспределения/ВыбратьПоСсылке/100', timeout: 200},
				fields:
				[
					{
						name:'Ссылка',
					},
					{
						name:'Использование',
					},
					{
						name:'Поле',
					},
					{
						name:'ТипУпорядочивания',
					},
				]
			},
			listeners:
			{
				dblclick:
				{
					element: 'body',
					fn: function ()
					{
						var грид = Ext.getCmp('Порядок');
						var ссылка = грид.getView().getSelectionModel().getSelection()[0].data.Ссылка;
						var Хранилище = грид.store;
						var стрЗнач = Хранилище.findRecord('Ссылка', ссылка).data;
						Ext.require(['Справочники.РедактированиеДанныхРаспределения.ФормаНастройкиСобытия'], function ()
						{
							var obj = Ext.create("Справочники.РедактированиеДанныхРаспределения.ФормаНастройкиСобытия");
							obj.ПередатьСсылку(стрЗнач);
						});
					}
				}
			},
		},
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:743px;top:6px;width:24px;height:187px;',
			items:
			[
			]
		},
					]
				},
				{
					title:'Условное оформление',
					items:
					[
		{
			id: 'УсловноеОформление',
			xtype: 'grid',
			style: 'position:absolute;left:6px;top:6px;width:735px;height:187px;',
			height: 187,width: 735,
			columns:
			[
				{
					text:'',
					width:'20',
					dataIndex:'Использование',
					flex:1,
				},
				{
					text:'Область',
					width:'100',
					dataIndex:'ОбластиДляКраткогоОтображенияЭлемента',
					flex:1,
				},
				{
					text:'Отбор',
					width:'100',
					dataIndex:'ОтборДляКраткогоОтображенияЭлемента',
					flex:1,
				},
				{
					text:'Оформление',
					width:'100',
					dataIndex:'ОформлениеДляКраткогоОтображенияЭлемента',
					flex:1,
				},
				{
					text:'Представление',
					width:'100',
					dataIndex:'ПредставлениеДляКраткогоОтображенияЭлемента',
					flex:1,
				},
				{
					text:'Область',
					width:'100',
					dataIndex:'ОбластиДляПодробногоОтображенияЭлемента',
					flex:1,
				},
				{
					text:'Отбор',
					width:'100',
					dataIndex:'ОтборДляПодробногоОтображенияЭлемента',
					flex:1,
				},
				{
					text:'Оформление',
					width:'100',
					dataIndex:'ОформлениеДляПодробногоОтображенияЭлемента',
					flex:1,
				},
				{
					text:'Представление',
					width:'100',
					dataIndex:'ПредставлениеДляПодробногоОтображенияЭлемента',
					flex:1,
				},
			],
			store:
			{
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/РедактированиеДанныхРаспределения/ВыбратьПоСсылке/100', timeout: 200},
				fields:
				[
					{
						name:'Ссылка',
					},
					{
						name:'Использование',
					},
					{
						name:'ОбластиДляКраткогоОтображенияЭлемента',
					},
					{
						name:'ОтборДляКраткогоОтображенияЭлемента',
					},
					{
						name:'ОформлениеДляКраткогоОтображенияЭлемента',
					},
					{
						name:'ПредставлениеДляКраткогоОтображенияЭлемента',
					},
					{
						name:'ОбластиДляПодробногоОтображенияЭлемента',
					},
					{
						name:'ОтборДляПодробногоОтображенияЭлемента',
					},
					{
						name:'ОформлениеДляПодробногоОтображенияЭлемента',
					},
					{
						name:'ПредставлениеДляПодробногоОтображенияЭлемента',
					},
				]
			},
			listeners:
			{
				dblclick:
				{
					element: 'body',
					fn: function ()
					{
						var грид = Ext.getCmp('УсловноеОформление');
						var ссылка = грид.getView().getSelectionModel().getSelection()[0].data.Ссылка;
						var Хранилище = грид.store;
						var стрЗнач = Хранилище.findRecord('Ссылка', ссылка).data;
						Ext.require(['Справочники.РедактированиеДанныхРаспределения.ФормаНастройкиСобытия'], function ()
						{
							var obj = Ext.create("Справочники.РедактированиеДанныхРаспределения.ФормаНастройкиСобытия");
							obj.ПередатьСсылку(стрЗнач);
						});
					}
				}
			},
		},
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:743px;top:6px;width:24px;height:187px;',
			items:
			[
			]
		},
					]
				},
				{
					title:'Пользовательские поля',
					items:
					[
		{
			id: 'ПользовательскиеПоля',
			xtype: 'grid',
			style: 'position:absolute;left:6px;top:6px;width:735px;height:187px;',
			height: 187,width: 735,
			columns:
			[
				{
					text:'Пользовательские поля',
					width:'100',
					dataIndex:'Заголовок',
					flex:1,
				},
			],
			store:
			{
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/РедактированиеДанныхРаспределения/ВыбратьПоСсылке/100', timeout: 200},
				fields:
				[
					{
						name:'Ссылка',
					},
					{
						name:'Заголовок',
					},
				]
			},
			listeners:
			{
				dblclick:
				{
					element: 'body',
					fn: function ()
					{
						var грид = Ext.getCmp('ПользовательскиеПоля');
						var ссылка = грид.getView().getSelectionModel().getSelection()[0].data.Ссылка;
						var Хранилище = грид.store;
						var стрЗнач = Хранилище.findRecord('Ссылка', ссылка).data;
						Ext.require(['Справочники.РедактированиеДанныхРаспределения.ФормаНастройкиСобытия'], function ()
						{
							var obj = Ext.create("Справочники.РедактированиеДанныхРаспределения.ФормаНастройкиСобытия");
							obj.ПередатьСсылку(стрЗнач);
						});
					}
				}
			},
		},
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:743px;top:6px;width:24px;height:187px;',
			items:
			[
			]
		},
					]
				},
				{
					title:'Другие настройки',
					items:
					[
		{
			id: 'ПараметрыВывода',
			xtype: 'grid',
			style: 'position:absolute;left:6px;top:6px;width:735px;height:187px;',
			height: 187,width: 735,
			columns:
			[
				{
					text:'',
					width:'20',
					dataIndex:'Использование',
					flex:1,
				},
				{
					text:'Параметр',
					width:'100',
					dataIndex:'Параметр',
					flex:1,
				},
				{
					text:'Значение',
					width:'100',
					dataIndex:'Значение',
					flex:1,
				},
				{
					text:'Параметр',
					width:'100',
					dataIndex:'ПараметрСДатой',
					flex:1,
				},
				{
					text:'Значение',
					width:'50',
					dataIndex:'ЗначениеСДатой',
					flex:1,
				},
				{
					text:'Дата',
					width:'50',
					dataIndex:'ДатаЗначениеСДатой',
					flex:1,
				},
				{
					text:'Дата начала',
					width:'100',
					dataIndex:'ДатаНачала',
					flex:1,
				},
				{
					text:'Дата окончания',
					width:'100',
					dataIndex:'ДатаОкончания',
					flex:1,
				},
			],
			store:
			{
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/РедактированиеДанныхРаспределения/ВыбратьПоСсылке/100', timeout: 200},
				fields:
				[
					{
						name:'Ссылка',
					},
					{
						name:'Использование',
					},
					{
						name:'Параметр',
					},
					{
						name:'Значение',
					},
					{
						name:'ПараметрСДатой',
					},
					{
						name:'ЗначениеСДатой',
					},
					{
						name:'ДатаЗначениеСДатой',
					},
					{
						name:'ДатаНачала',
					},
					{
						name:'ДатаОкончания',
					},
				]
			},
			listeners:
			{
				dblclick:
				{
					element: 'body',
					fn: function ()
					{
						var грид = Ext.getCmp('ПараметрыВывода');
						var ссылка = грид.getView().getSelectionModel().getSelection()[0].data.Ссылка;
						var Хранилище = грид.store;
						var стрЗнач = Хранилище.findRecord('Ссылка', ссылка).data;
						Ext.require(['Справочники.РедактированиеДанныхРаспределения.ФормаНастройкиСобытия'], function ()
						{
							var obj = Ext.create("Справочники.РедактированиеДанныхРаспределения.ФормаНастройкиСобытия");
							obj.ПередатьСсылку(стрЗнач);
						});
					}
				}
			},
		},
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:743px;top:6px;width:24px;height:187px;',
			items:
			[
			]
		},
					]
				},
			]
		},
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:0px;top:485px;width:790px;height:25px;',
			items:
			[
				{
					xtype: 'tbfill'
				},
				{
					text:'OK',
				},
				'-',
				{
					text:'Отмена',
				},
				'-',
				{
					text:'Справка',
				},
			]
		},
		],
	}],
	dockedItems:
	[
	]
	});
});