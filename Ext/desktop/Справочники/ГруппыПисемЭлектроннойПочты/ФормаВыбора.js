﻿Ext.define('Справочники.ГруппыПисемЭлектроннойПочты.ФормаВыбора',
	{
	extend: 'Ext.window.Window',
	style: 'position:absolute;width:456px;height:321px;',
	iconCls: 'bogus',
	minimizable: true,
	maximizable: true,
	title: 'Справочник Группы писем электронной почты',
	
	items:
	[{
		xtype: 'form',
		items:
		[
		{
			id: 'СправочникСписок',
			xtype: 'grid',
			style: 'position:absolute;left:8px;top:33px;width:440px;height:280px;',
			height: 280,width: 440,
			columns:
			[
				{
					text:'Наименование',
					width:'2200',
					dataIndex:'Наименование',
					flex:1,
				},
				{
					text:'Владелец',
					width:'2200',
					dataIndex:'Владелец',
					flex:1,
				},
			],
			store:
			{
				data: Ext.create("Данные.Справочники.ГруппыПисемЭлектроннойПочты").data,
				autoLoad: true,
				pageSize: 50,
				restful: true,
				autoSync: false,
				proxy: {type: 'jsonp',url: 'https://localhost:1337/Справочники/ГруппыПисемЭлектроннойПочты/ВыбратьПоСсылке/100', timeout: 3},
				fields:
				[
					{
						name:'Наименование',
					},
					{
						name:'Владелец',
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
			style: 'position:absolute;left:0px;top:0px;width:456px;height:25px;',
			dock: 'top',
			items:
			[
				{
					text:'Выбрать',
				},
				'-',
			]
		},
	]
});