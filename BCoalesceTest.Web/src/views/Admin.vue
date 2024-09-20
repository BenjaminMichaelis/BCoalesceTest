<template>
  <v-container style="max-width: 800px">
    <v-card>
      <v-card-title> Coalesce Admin Tables </v-card-title>

      <v-card-text>
        <v-list density="compact">
          <v-list-item
            v-for="type in adminTypes"
            :key="type.name"
            :title="type.displayName"
            :subtitle="type.description"
            :to="{
              name: 'coalesce-admin-list',
              params: { type: type.name },
            }"
          >
            <template #prepend>
              <v-avatar color="surface-variant" class="font-weight-bold ml-n1">
                {{
                  type.displayName
                    .split(" ")
                    .map((w) => w[0])
                    .join("")
                    .slice(0, 4)
                }}
              </v-avatar>
            </template>
          </v-list-item>
        </v-list>
      </v-card-text>
    </v-card>
    <br />
    <v-card>
      <v-card-title> Other Pages </v-card-title>

      <v-card-text>
        <v-list compact>
          <v-list-item
            title="Coalesce Security Overview"
            subtitle="An overview of how each property, method, and endpoint is served by Coalesce."
            href="/coalesce-security"
            prepend-icon="fa fa-lock-open"
          >
          </v-list-item>
        </v-list>
      </v-card-text>
    </v-card>
  </v-container>
</template>

<script setup lang="ts">
import $metadata from "@/metadata.g";
import { Domain, ModelType } from "coalesce-vue";

const excludedTypes: Array<keyof typeof $metadata.types> = [];

const adminTypes = Object.values(($metadata as Domain).types).filter(
  //@ts-ignore may be errors if the project has only model or only object types
  (t): t is ModelType => t.type == "model" && !excludedTypes.includes(t.name),
);
</script>
