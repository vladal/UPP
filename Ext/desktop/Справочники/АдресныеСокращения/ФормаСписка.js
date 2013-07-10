﻿Ext.define('Справочники.АдресныеСокращения.ФормаСписка',
	{
	extend: 'Ext.window.Window',
	style: 'position:absolute;width:436px;height:361px;',
	iconCls: 'bogus',
	minimizable: true,
	maximizable: true,
	title: 'Адресные сокращения',
	
	items:
	[{
		xtype: 'form',
		items:
		[
		{
			id: 'СправочникСписок',
			xtype: 'grid',
			style: 'position:absolute;left:8px;top:33px;width:420px;height:320px;',
			height: 320,width: 420,
			columns:
			[
				{
					text:'',
					width:'32',
					dataIndex:'Картинка',
					flex:1,
				},
				{
					text:'Код',
					width:'40',
					dataIndex:'Код',
					flex:1,
				},
				{
					text:'Наименование',
					width:'2200',
					dataIndex:'Наименование',
					flex:1,
				},
				{
					text:'Уровень',
					width:'48',
					dataIndex:'Уровень',
					flex:1,
				},
				{
					text:'Сокращение',
					width:'80',
					dataIndex:'Сокращение',
					flex:1,
				},
			],
			store:
			{
				data: Ext.create("Данные.Справочники.АдресныеСокращения").data,
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/АдресныеСокращения/ВыбратьПоСсылке/100', timeout: 3},
				fields:
				[
					{
						name:'Картинка',
					},
					{
						name:'Код',
					},
					{
						name:'Наименование',
					},
					{
						name:'Уровень',
					},
					{
						name:'Сокращение',
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
						var грид = Ext.getCmp('СправочникСписок');
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
		],
	}],
	dockedItems:
	[
		{
			xtype: 'toolbar',
			style: 'position:absolute;left:0px;top:0px;width:436px;height:25px;',
			dock: 'top',
			items:
			[
			]
		},
	]
});