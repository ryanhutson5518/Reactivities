import React from 'react';
import { Grid } from 'semantic-ui-react';
import { Activity } from '../../../app/models/activity';
import ActivityList from './ActivityList';
import ActivityDetails from '../details/ActivityDetails';

interface Props {
    activities: Activity[];
}

export default function ActivityDashboard({ activities }: Props) {   // Destructure this object in order to get type safety
    return (
        <Grid>
            <Grid.Column width='10'>
                <ActivityList activities={activities} />
            </Grid.Column>
            <Grid.Column width='6'>
                <ActivityDetails activity={activities[0]} />
            </Grid.Column>
        </Grid>
    );
}