using System;
using System.Collections.Generic;
using System.Text;

namespace SampleEventGenerator
{
    public static class Json
    {
        public static string json= @"{
	'id': '6073967d30c49e0006ebb0a7',
	'PhenomenonTime': '1618188230',
	'Sensors': {
		'DeviceId': 'Sensor1',
		'metadata': {
			'name': 'AccelerometerSensor',
			'desc': 'Gives acceleration values of hand movement'
		},
		'QuantityKind': 'Acceleration',
		'DeviceDeployment': {
			'location': {
				'type': 'circle',
				'lat': 110.110,
				'long': 91.91,
				'r': 50
			}
		},
		'Observations': [{
			'Acceleration': {
				'id': 'Obs_1',
				'type': 'float',
				'Value': {
					'x': 1.5795,
					'y': 0.2534,
					'z': -0.44
				}
			},
			'ResultTime': '1502852259713'
		}]
	}
}";
    }
}
