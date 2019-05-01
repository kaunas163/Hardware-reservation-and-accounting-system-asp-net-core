"use strict";

Object.defineProperty(exports, "__esModule", {
  value: true
});
exports["default"] = void 0;

var _vue = _interopRequireDefault(require("@fullcalendar/vue"));

var _daygrid = _interopRequireDefault(require("@fullcalendar/daygrid"));

var _timegrid = _interopRequireDefault(require("@fullcalendar/timegrid"));

var _interaction = _interopRequireDefault(require("@fullcalendar/interaction"));

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { "default": obj }; }

var _default = {
  components: {
    FullCalendar: _vue["default"] // make the <FullCalendar> tag available

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
};
exports["default"] = _default;