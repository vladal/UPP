﻿Ext.define('Обработки.КлиентБанк.ФормаНастройкиЗаполнения',
	{
	extend: 'Ext.window.Window',
	style: 'position:absolute;width:670px;height:286px;',
	iconCls: 'bogus',
	minimizable: true,
	maximizable: true,
	title: 'Настройка',
	
	items:
	[{
		xtype: 'form',
		items:
		[
		{
			xtype: 'tabpanel',
			style: 'position:absolute;left:8px;top:8px;width:654px;height:222px;',
			height: 222,width: 654,
			items:
			[
				{
					title:'Обмен данными с программой "Клиент банка"',
					items:
					[
		{
			id: 'ТаблицаДокументов',
			xtype: 'grid',
			style: 'position:absolute;left:6px;top:92px;width:317px;height:101px;',
			height: 101,width: 317,
			columns:
			[
				{
					text:'',
					width:'21',
					dataIndex:'_',
					flex:1,
				},
				{
					text:'Документ',
					width:'146',
					dataIndex:'Документ',
					flex:1,
				},
			],
			store:
			{
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/КлиентБанк/ВыбратьПоСсылке/100', timeout: 3},
				fields:
				[
					{
						name:'_',
					},
					{
						name:'Документ',
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
						var грид = Ext.getCmp('ТаблицаДокументов');
						var ссылка = грид.getView().getSelectionModel().getSelection()[0].data;
						Ext.require(['Справочники.Банки.ФормаЭлементаСобытия'], function ()
						{
							var obj = Ext.create("Справочники.Банки.ФормаЭлементаСобытия");
							obj.ПередатьСсылку(ссылка);
						});
					}
				}
			},
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'Программа',
			width: 348,
			height: 19,
			style: 'position:absolute;left:129px;top:41px;width:348px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'Надпись5',
			text: 'Название программы:',
			style: 'position:absolute;left:6px;top:41px;width:120px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьКодировка',
			text: 'Кодировка:',
			style: 'position:absolute;left:353px;top:154px;width:61px;height:19px;text-align:left;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'ФайлЗагрузки',
			width: 293,
			height: 19,
			style: 'position:absolute;left:353px;top:92px;width:293px;height:19px;',
		},
		{
			xtype: 'textfield',
			hideLabel: true,
			disabled: false,
			name: 'ФайлВыгрузки',
			width: 293,
			height: 19,
			style: 'position:absolute;left:353px;top:135px;width:293px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'НадписьБанковскийСчет',
			text: 'Обслуживаемый банковский счет:',
			style: 'position:absolute;left:6px;top:6px;width:120px;height:32px;text-align:left;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			trigger2Cls: 'x-form-search-trigger',
			name: 'БанковскийСчет',
			width: 348,
			height: 19,
			style: 'position:absolute;left:129px;top:12px;width:348px;height:19px;',
		},
		{
			xtype: 'label',
			name: 'Надпись1',
			text: 'Виды выгружаемых платежных документов:',
			style: 'position:absolute;left:6px;top:70px;width:317px;height:17px;',
		},
		{
			xtype: 'label',
			name: 'Надпись6',
			text: 'Файл загрузки:',
			style: 'position:absolute;left:353px;top:70px;width:293px;height:17px;',
		},
		{
			xtype: 'label',
			name: 'Надпись7',
			text: 'Файл выгрузки:',
			style: 'position:absolute;left:353px;top:115px;width:293px;height:15px;',
		},
		{
			xtype: 'radiogroup',
			defaults: {name: 'ccType'},
			items: [
		{
			xtype: 'radio',
			boxLabel: 'DOS',
			style: 'position:absolute;left:418px;top:154px;width:51px;height:19px;',
		},
		{
			xtype: 'radio',
			boxLabel: 'Windows',
			style: 'position:absolute;left:418px;top:174px;width:66px;height:19px;',
		},
			]
		},
					]
				},
				{
					title:'Загрузка',
					items:
					[
		{
			id: 'ТаблицаНастроек',
			xtype: 'grid',
			style: 'position:absolute;left:6px;top:6px;width:640px;height:156px;',
			height: 156,width: 640,
			columns:
			[
				{
					text:'Вид документа',
					width:'148',
					dataIndex:'Документ',
					flex:1,
				},
				{
					text:'Проводить 
при загрузке',
					width:'80',
					dataIndex:'Проводить',
					flex:1,
				},
				{
					text:'Статья ДДС для новых документов',
					width:'2100',
					dataIndex:'СтатьяДДС',
					flex:1,
				},
			],
			store:
			{
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/КлиентБанк/ВыбратьПоСсылке/100', timeout: 3},
				fields:
				[
					{
						name:'Документ',
					},
					{
						name:'Проводить',
					},
					{
						name:'СтатьяДДС',
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
						var грид = Ext.getCmp('ТаблицаНастроек');
						var ссылка = грид.getView().getSelectionModel().getSelection()[0].data;
						Ext.require(['Справочники.Банки.ФормаЭлементаСобытия'], function ()
						{
							var obj = Ext.create("Справочники.Банки.ФормаЭлементаСобытия");
							obj.ПередатьСсылку(ссылка);
						});
					}
				}
			},
		},
		{
			xtype: 'label',
			name: 'Надпись8',
			text: 'Группа для новых контрагентов:',
			style: 'position:absolute;left:6px;top:173px;width:177px;height:19px;',
		},
		{
			xtype: 'trigger',
			hideLabel: true,
			disabled: false,
			trigger1Cls: 'x-form-select-trigger',
			trigger2Cls: 'x-form-clear-trigger',
			name: 'ГруппаДляНовыхКонтрагентов',
			width: 240,
			height: 19,
			style: 'position:absolute;left:184px;top:173px;width:240px;height:19px;',
		},
					]
				},
			]
		},
		{
			xtype: 'checkbox',
			boxLabel: 'Не контролировать окончание номера на 000',
			style: 'position:absolute;left:8px;top:236px;width:254px;height:25px;',
		},
		],
	}],
	dockedItems:
	[
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:0px;top:261px;width:670px;height:25px;',
			dock: 'bottom',
			items:
			[
				{
					xtype: 'tbfill'
				},
				{
					text:'ОК',
				},
				'-',
				{
					text:'Закрыть',
				},
				'-',
			]
		},
	]
});