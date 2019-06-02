"use strict";

var _vue = _interopRequireDefault(require("vue/dist/vue.js"));

var _vue2 = _interopRequireDefault(require("@fullcalendar/vue"));

var _daygrid = _interopRequireDefault(require("@fullcalendar/daygrid"));

var _timegrid = _interopRequireDefault(require("@fullcalendar/timegrid"));

var _interaction = _interopRequireDefault(require("@fullcalendar/interaction"));

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { "default": obj }; }

// import Calendar from './Calendar.js'
// new Vue({
//     render: h => h(Calendar)
// }).$mount('#calendar')
// Vue.component('calendar');
_vue["default"].component('calendar', {
  template: "\n        <FullCalendar\n            class='demo-app-calendar'\n            ref=\"fullCalendar\"\n            defaultView=\"dayGridMonth\"\n            selectable=\"true\"\n            :header=\"{\n                left: 'prev,next today',\n                center: 'title',\n                right: 'dayGridMonth,timeGridWeek,timeGridDay,listWeek'\n            }\"\n            :plugins=\"calendarPlugins\"\n            :weekends=\"calendarWeekends\"\n            :events=\"calendarEvents\"\n            @@dateClick=\"handleDateClick\"\n        />\n    ",
  components: {
    FullCalendar: _vue2["default"] // make the <FullCalendar> tag available

  },
  data: function data() {
    return {
      calendarPlugins: [// plugins must be defined in the JS
      _daygrid["default"], _timegrid["default"], _interaction["default"] // needed for dateClick
      ],
      calendarWeekends: true,
      calendarEvents: [// initial event data
      {
        title: 'Event Now',
        start: new Date()
      }]
    };
  },
  methods: {
    toggleWeekends: function toggleWeekends() {
      this.calendarWeekends = !this.calendarWeekends; // update a property
    },
    gotoPast: function gotoPast() {
      var calendarApi = this.$refs.fullCalendar.getApi(); // from the ref="..."

      calendarApi.gotoDate('2000-01-01'); // call a method on the Calendar object
    },
    handleDateClick: function handleDateClick(arg) {
      if (confirm('Would you like to add an event to ' + arg.dateStr + ' ?')) {
        this.calendarEvents.push({
          // add new event data
          title: 'New Event',
          start: arg.date,
          allDay: arg.allDay
        });
      }
    }
  }
});

_vue["default"].component('export-modal', {
  data: function data() {
    return {
      exportData: 'all',
      fileFormat: 'pdf'
    };
  },
  computed: {
    exportAllData: function exportAllData() {
      return this.exportData == 'all' ? 'btn-dark' : 'btn-link';
    },
    exportFilteredData: function exportFilteredData() {
      return this.exportData == 'filtered' ? 'btn-dark' : 'btn-link';
    },
    pdfFileFormat: function pdfFileFormat() {
      return this.fileFormat == 'pdf' ? 'btn-dark' : 'btn-link';
    },
    csvFileFormat: function csvFileFormat() {
      return this.fileFormat == 'csv' ? 'btn-dark' : 'btn-link';
    },
    jsonFileFormat: function jsonFileFormat() {
      return this.fileFormat == 'json' ? 'btn-dark' : 'btn-link';
    },
    exportDataClass: function exportDataClass(element) {
      return this.exportData == element ? 'btn-dark' : 'btn-link';
    }
  }
});

_vue["default"].component('related-to-toggler', {
  data: function data() {
    return {
      togglerOn: false
    };
  },
  computed: {
    togglerText: function togglerText() {
      return this.togglerOn ? 'taip' : 'ne';
    }
  }
});

_vue["default"].component('add-equipment-to-bundle-block-element', {
  data: function data() {
    return {
      checked: false
    };
  }
});

_vue["default"].component('choose-bundle-for-reservation-block', {
  data: function data() {
    return {
      selectedBundle: ''
    };
  }
});

_vue["default"].component('choose-bundle-for-reservation-block-item', {
  model: {
    prop: 'selectedBundle',
    event: 'onUpdateSelectedBundle'
  },
  props: ['bundleId', 'selectedBundle'],
  methods: {
    updateSelectedBundle: function updateSelectedBundle() {
      this.$emit('onUpdateSelectedBundle', this.bundleId);
    }
  }
});

new _vue["default"]({
  el: '#app-root',
  data: function data() {
    return {
      currentViewMode: '',
      initialViewMode: true,
      sidebarEquipmentActive: false
    };
  },
  methods: {
    changeViewMode: function changeViewMode(mode) {
      this.initialViewMode = false;
      this.currentViewMode = mode;
    }
  },
  computed: {
    listViewMode: function listViewMode() {
      return this.currentViewMode == 'list' ? 'active' : '';
    },
    tableViewMode: function tableViewMode() {
      return this.currentViewMode == 'table' ? 'active' : '';
    },
    calendarViewMode: function calendarViewMode() {
      // let calendarApi = this.$refs.fullCalendar.getApi();
      // calendarApi.render();
      // fullCalendar.render();
      // console.log(this.$refs);
      return this.currentViewMode == 'calendar' ? 'active' : '';
    },
    gridViewMode: function gridViewMode() {
      return this.currentViewMode == 'grid' ? 'active' : '';
    }
  }
}); // new Vue({
//     el: '#calendar',
//     components: {
//         FullCalendar
//     },
//     data: function() {
//         return {
//                 calendarPlugins: [ // plugins must be defined in the JS
//                 dayGridPlugin,
//                 timeGridPlugin,
//                 interactionPlugin // needed for dateClick
//             ],
//             calendarWeekends: true,
//             calendarEvents: [ // initial event data
//                 { title: 'Event Now', start: new Date() }
//             ]
//         }
//     },
//     methods: {
//         toggleWeekends() {
//             this.calendarWeekends = !this.calendarWeekends // update a property
//         },
//         gotoPast() {
//             let calendarApi = this.$refs.fullCalendar.getApi() // from the ref="..."
//             calendarApi.gotoDate('2000-01-01') // call a method on the Calendar object
//         },
//         handleDateClick(arg) {
//             if (confirm('Would you like to add an event to ' + arg.dateStr + ' ?')) {
//                 this.calendarEvents.push({ // add new event data
//                     title: 'New Event',
//                     start: arg.date,
//                     allDay: arg.allDay
//                 })
//             }
//         }
//     }
// });
// import Calendar from './Calendar.vue'
// Vue.component('Calendar');
// new Vue({
// el: '#demo-app-placeholder'
// });
// new Vue({
//     render: h => h(Calendar)
// }).$mount('#demo-app-placeholder')
// new Vue({
//     el: '#demo-app-placeholder',
//     render: function (h) {
//         return h(require('./Calendar.vue'));
//     }
// });